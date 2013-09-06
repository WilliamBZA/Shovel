Require<Shovel>();

"TransformXMLTest"
	.TransformXML(xdt =>
	{
		xdt.Source = @"xdt-source.xml";
		xdt.Transform = @"xdt-transform.xml";
	});
