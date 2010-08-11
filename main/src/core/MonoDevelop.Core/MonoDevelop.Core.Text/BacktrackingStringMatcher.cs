// 
// BacktrackingStringMatcher.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2010 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace MonoDevelop.Core.Text
{
	class BacktrackingStringMatcher: StringMatcher
	{
		readonly string filterTextUpperCase;

		readonly bool[] filterTextLowerCaseTable;
		readonly bool[] filterIsNonLetter;

		int[] cachedResult;

		public BacktrackingStringMatcher (string filterText)
		{
			if (filterText != null) {
				filterTextLowerCaseTable = new bool[filterText.Length];
				filterIsNonLetter = new bool[filterText.Length];
				for (int i = 0; i < filterText.Length; i++) {
					filterTextLowerCaseTable[i] = char.IsLower (filterText[i]);
					filterIsNonLetter[i] = !char.IsLetter (filterText[i]);
				}
				
				filterTextUpperCase = filterText.ToUpper ();
			} else {
				filterTextUpperCase = "";
			}
		}

		public override bool CalcMatchRank (string name, out int matchRank)
		{
			if (filterTextUpperCase.Length == 0) {
				matchRank = int.MinValue;
				return true;
			}
			var lane = GetMatch (name);
			if (lane != null) {
				matchRank = -(lane[0] + (name.Length - filterTextUpperCase.Length));
				return true;
			}
			matchRank = int.MinValue;
			return false;
		}

		public override bool IsMatch (string text)
		{
			int[] match = GetMatch (text);
			// no need to clear the cache
			cachedResult = cachedResult ?? match;
			return match != null;
		}

		int GetMatchChar (string text, int i, int j, bool onlyWordStart)
		{
			char filterChar = filterTextUpperCase[i];
			// filter char is no letter -> search for next exact match
			if (filterIsNonLetter[i]) {
				for (; j < text.Length; j++) {
					if (filterChar == text[j])
						return j;
				}
				return -1;
			}
			
			// letter case
			bool textCharIsUpper = char.IsUpper (text[j]);
			if (!onlyWordStart && (textCharIsUpper || filterTextLowerCaseTable[i]) && filterChar == (textCharIsUpper ? text[j] : char.ToUpper (text[j]))) {
				return j;
			}
			
			// no match, try to continue match at the next word start
			j++;
			for (; j < text.Length; j++) {
				if (char.IsUpper (text[j]) && filterChar == text[j])
					return j;
			}
			return -1;
		}
		
		/// <summary>
		/// Gets the match indices.
		/// </summary>
		/// <returns>
		/// The indices in the text which are matched by our filter.
		/// </returns>
		/// <param name='text'>
		/// The text to match.
		/// </param>
		public override int[] GetMatch (string text)
		{
			if (string.IsNullOrEmpty (filterTextUpperCase))
				return new int[0];
			if (string.IsNullOrEmpty (text))
				return null;
			int[] result;
			if (cachedResult != null) {
				result = cachedResult;
			} else {
				cachedResult = result = new int[filterTextUpperCase.Length];
			}
			int j = 0;
			int i = 0;
			bool onlyWordStart = false;
			while (i < filterTextUpperCase.Length) {
				if (j >= text.Length) {
					if (i > 0) {
						j = result[--i] + 1;
						onlyWordStart = true;
						continue;
					}
					return null;
				}
				j = GetMatchChar (text, i, j, onlyWordStart);
				onlyWordStart = false;
				if (j == -1) {
					if (i > 0) {
						j = result[--i] + 1;
						onlyWordStart = true;
						continue;
					}
					return null;
				} else {
					result[i] = j++;
				}
				i++;
			}
			cachedResult = null;
			// clear cache
			return result;
		}
	}
}

