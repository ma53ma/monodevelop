﻿//
// DotNetCoreProjectTests.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2016 Xamarin Inc. (http://xamarin.com)
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

using System.Linq;
using System.Threading.Tasks;
using MonoDevelop.Projects;
using NUnit.Framework;
using UnitTests;

namespace MonoDevelop.DotNetCore
{
	[TestFixture]
	class DotNetCoreProjectExtensionTests : TestBase
	{
		/// <summary>
		/// ProjectGuid and DefaultTargets should not be added to .NET Core project when it is saved.
		/// </summary>
		[Test]
		public async Task ConsoleProject_SaveProject_DoesNotAddExtraProperties ()
		{
			string solutionFileName = Util.GetSampleProject ("dotnetcore-console", "dotnetcore-console.sln");
			var solution = (Solution) await Services.ProjectService.ReadWorkspaceItem (Util.GetMonitor (), solutionFileName);
			var project = solution.GetAllProjects ().Single ();

			// Original project does not have ProjectGuid nor DefaultTargets.
			var globalPropertyGroup = project.MSBuildProject.GetGlobalPropertyGroup ();
			Assert.IsFalse (globalPropertyGroup.HasProperty ("ProjectGuid"));
			Assert.IsNull (project.MSBuildProject.DefaultTargets);

			await project.SaveAsync (Util.GetMonitor ());

			// Reload project.
			solution = (Solution) await Services.ProjectService.ReadWorkspaceItem (Util.GetMonitor (), solutionFileName);
			project = solution.GetAllProjects ().Single ();

			globalPropertyGroup = project.MSBuildProject.GetGlobalPropertyGroup ();

			Assert.IsFalse (globalPropertyGroup.HasProperty ("ProjectGuid"));
			Assert.IsNull (project.MSBuildProject.DefaultTargets);
		}
	}
}