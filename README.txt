Put Config.XML in folder with DLL. ( e.g. bin/debug)

master - stable version of test. Work on PageObject and Page Element patterns

FactoryTry - same test but using Facility ( custom Factory) to initialize elements of PageObject

test:
	steps:
		1.Create new insured
		2.Create new RFQ in this insured
		3.Check its XMl( main information shouls be in appropriate tag )
		4.Create other RFQ but with different line
		5.Check XML (main information shouls be in appropriate tag differ from step 3 )