using System.IO;
using NUnit.Framework;
using ShovelPack.TaskActions.XMLTransformer;

namespace Shovel.Tests.TaskActions.TransformXML
{
	[TestFixture]
	public class XmlTransformerTests
	{
		[Test]
		public void CanTransformSourceXMLFileUsingTransformFile()
		{
			const string sourceFile = @"TaskActions\TransformXML\transform-source.xml";
			const string transformFile = @"TaskActions\TransformXML\transform-xdt.xml";
			const string outputFile = @"TaskActions\TransformXML\result.xml";

			File.Delete(outputFile);

			var transformer = new XmlTransformer();
			transformer.Transform(sourceFile, transformFile, outputFile);

			var result = File.ReadAllText(outputFile);
			Assert.That(result, Contains.Substring("the-replaced-element-after-transformation"));
			Assert.That(result, Contains.Substring("This section should remain untouched after transformation."));
		}
	}
}