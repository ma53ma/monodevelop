﻿//
// AtkCocoaHelperNoOp.cs
//
// Author:
//       iain <iaholmes@microsoft.com>
//
// Copyright (c) 2017 
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

#if !MAC

using System;
using Gdk;
using Gtk;

namespace Mono.TextEditor.AtkCocoaHelper
{
	public static class AtkCocoaNoopExtensions
	{
		public static void SetLabel (this Atk.Object o, string label)
		{
		}

		public static void SetLabel (this Gtk.CellRenderer r, string label)
		{
		}

		public static void SetAccessibilityDescription (this Gtk.CellRenderer r, string description)
		{
		}

		public static void SetShouldIgnore (this Atk.Object o, bool ignore)
		{
		}

		public static void SetTitle (this Atk.Object o, string title)
		{
		}

		public static void SetDocument (this Atk.Object o, string documentUrl)
		{
		}

		public static void SetFilename (this Atk.Object o, string filename)
		{
		}

		public static void SetIsMainWindow (this Atk.Object o, bool isMainWindow)
		{
		}

		public static void SetMainWindow (this Atk.Object o, Atk.Object mainWindow)
		{
		}

		public static void SetValue (this Atk.Object o, string stringValue)
		{
		}

		public static void SetUrl (this Atk.Object o, string url)
		{
		}

		public static void SetRole (this Atk.Object o, string role, string description = null)
		{
		}

		public static void SetRole (this Atk.Object o, AtkCocoa.Roles role, string description = null)
		{
		}

		public static void SetSubRole (this Atk.Object o, string subrole)
		{
		}

		public static void SetTitleUIElement (this Atk.Object o, Atk.Object title)
		{
		}

		public static void SetAlternateUIVisible (this Atk.Object o, bool visible)
		{
		}

		public static void SetOrientation (this Atk.Object o, Gtk.Orientation orientation)
		{
		}

		public static void SetTitleFor (this Atk.Object o, params Atk.Object [] objects)
		{
		}

		public static void SetTabs (this Atk.Object o, AccessibilityElementProxy [] tabs)
		{
		}

		public static void SetTabs (this Atk.Object o, Atk.Object [] tabs)
		{
		}

		public static void AddElementToTitle (this Atk.Object title, Atk.Object o)
		{
		}

		public static void RemoveElementFromTitle (this Atk.Object title, Atk.Object o)
		{
		}

		public static void ReplaceAccessibilityElements (this Atk.Object parent, AccessibilityElementProxy [] children)
		{
		}

		public static void SetAccessibilityColumns (this Atk.Object parent, AccessibilityElementProxy [] columns)
		{
		}

		public static void SetAccessibilityRows (this Atk.Object parent, AccessibilityElementProxy [] rows)
		{
		}

		public static void SetActionDelegate (this Atk.Object o, ActionDelegate ad)
		{
		}

		public static void AddAccessibleElement (this Atk.Object o, AccessibilityElementProxy child)
		{
		}

		public static void RemoveAccessibleElement (this Atk.Object o, AccessibilityElementProxy child)
		{
		}

		public static void SetAccessibleChildren (this Atk.Object o, AccessibilityElementProxy [] children)
		{
		}

		public static void AddAccessibleLinkedUIElement (this Atk.Object o, Atk.Object linked)
		{
		}
	}

	public class AccessibilityElementProxy : IAccessibilityElementProxy
	{
		public event EventHandler PerformCancel;
		public event EventHandler PerformConfirm;
		public event EventHandler PerformDecrement;
		public event EventHandler PerformDelete;
		public event EventHandler PerformIncrement;
		public event EventHandler PerformPick;
		public event EventHandler PerformPress;
		public event EventHandler PerformRaise;
		public event EventHandler PerformShowAlternateUI;
		public event EventHandler PerformShowDefaultUI;
		public event EventHandler PerformShowPopupMenu;

		public void AddAccessibleChild (IAccessibilityElementProxy child)
		{
		}

		public void SetHelp (string help)
		{
		}

		public void SetIdentifier (string identifier)
		{
		}

		public void SetLabel (string label)
		{
		}

		public void SetRole (AtkCocoa.Roles role, string description = null)
		{
		}

		public void SetRole (string role, string description = null)
		{
		}

		public void SetHidden (bool hidden)
		{
		}

		public void SetTitle (string title)
		{
		}

		public void SetValue (string value)
		{
		}

		public void SetFrameInParent (Rectangle rect)
		{
		}

		public void SetFrameInGtkParent (Rectangle frame)
		{
		}

		public void SetGtkParent (Widget realParent)
		{
		}
	}

	public class AccessibilityElementButtonProxy
	{
	}

	public abstract class AccessibilityElementNavigableStaticTextProxy : AccessibilityElementProxy, IAccessibilityNavigableStaticText
	{
		public abstract int InsertionPointLineNumber { get; }
		public abstract int NumberOfCharacters { get; }
		public abstract string Value { get; }

		public virtual Rectangle GetFrameForRange (AtkCocoa.Range range)
		{
			throw new NotImplementedException ();
		}

		public virtual int GetLineForIndex (int index)
		{
			throw new NotImplementedException ();
		}

		public virtual AtkCocoa.Range GetRangeForIndex (int index)
		{
			throw new NotImplementedException ();
		}

		public virtual AtkCocoa.Range GetRangeForLine (int line)
		{
			throw new NotImplementedException ();
		}

		public virtual AtkCocoa.Range GetRangeForPosition (Point position)
		{
			throw new NotImplementedException ();
		}

		public virtual string GetStringForRange (AtkCocoa.Range range)
		{
			throw new NotImplementedException ();
		}

		public virtual AtkCocoa.Range GetStyleRangeForIndex (int index)
		{
			throw new NotImplementedException ();
		}
	}
}

#endif
