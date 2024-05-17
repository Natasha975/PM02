using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Desktop_App;
using System.Linq;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var main = new AddPatientWindow();
			var result = main.GenerateUniqueCode();
			Assert.IsInstanceOfType(result, typeof(string));
		}
		[TestMethod]
		public void TestMethod2()
		{
			var main = new AddPatientWindow();
			var result = main.GenerateUniqueCode();
			Assert.AreEqual(6, result.Length);
		}
		[TestMethod]
		public void TestMethod3()
		{
			var main = new AddPatientWindow();
			var result = main.GenerateUniqueCode();
			Assert.IsTrue(result.All(char.IsLetterOrDigit));
		}
	}
}
