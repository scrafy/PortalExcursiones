﻿alter table `excursionactividad` add column `tipoduracion` nvarchar(60)  not null  ;
INSERT INTO `__MigrationHistory`(
`MigrationId`, 
`ContextKey`, 
`Model`, 
`ProductVersion`) VALUES (
'201612241617446_new_field_tipoduracion', 
'CapaDatos.Migrations.Configuration', 
0x1F8B0800000000000400ED7DDB8E1C3992E5FB00F30F897C1CD4287529D5F608A919A875E911BAA4122A55857D4B78863323BD15E11E72F75049B3D82FDB87F9A4F985A5DF7931238D74FA25548906AA5341D2481A8F1B8D46F2F07FFEDF7F5FFEC7D7FDEEEC0BCB8B244B9F9F3F7AF0F0FC8CA59B2C4ED2EDF3F36379FBAF7F39FF8F7FFFE77FBA7C1DEFBF9EFDDEE57B52E5E325D3E2F9F95D591E9E5D5C149B3BB68F8A07FB64936745765B3ED864FB8B28CE2E1E3F7CF86F178F1E5D302EE29CCB3A3BBBFCF59896C99ED5FFE0FF7C99A51B76288FD1EE5D16B35DD1FECE53AE6AA967EFA33D2B0ED1863D3F7F191DA257519915E7672F7649C41B70C576B7E767519A666554F2E63DFBAD6057659EA5DBAB03FF21DA7DFC76603CDF6DB42B58DBEC6743766A0F1E3EAE7A703114EC446D8E4599ED1D053E7AD2AAE4422DEEA5D8F35E655C69AFB972CB6F55AF6BC53D3F8F769F8FC98EE55FD85DB239EEB2F333B5D2672F77795540D0EF834A4C1CC5AC78A096FFE1ACCFF5430F0A8E9DEA7F3CEDB82B8F397B9EB2639947BB1FCE3E1C6F76C9E6EFECDBC7EC134B9FA7C7DD4E6C2F6F314F937EE03F7DC8B303CBCB6FBFB25BA517D7497C7E76210BB85025F4E5A1C24D4FDFA6E54F3F9E9FBDE7CD896E76AC0788A095AB32CBD9DF58CAF2A864F187A82C59CEC7F77D9632AD094A85D94DC115166DB8185674557258F20FEBFCEC5DF4F567966ECBBBE7E73F3D7DFAE4E9F9D99BE42B8BBBDFDA86FC9626FC4B1C1AA654F83EFA926CEB762A556FB2F436D91EF3BAF2F3B35FD9AECE55DC2587E66B7920E5B8D6E1F126CFF6BF663B559696F3FA63946F59C9BB9791B25F65C77CE3D0939C6DB22D076111B32FD9EED82913E89156155274E819AD44DFE4AE87C4629D62A83DEDC4117B276437F4A8CF65EFC590156AF9E5C560538C9646819E9B99910A2F63637C4C4B088BF23666B52A6D5625CDF63739339893470F1FD28C89D6488B39E3E028A3FC0F76D355FED78C23294A9D257D49629685E881B99A328ABF2445964F5F13FF5A0D953C9D663C76553573571A27DCD8355F365AF5E3A7B6D9ACCC8F1EFDCDB64140E358ED21CFBE301667A2DF0055FFF82F413A8D4E0FFA143DE5ACAECE16442780DA19F67573ACED79B429932F95F12774072A847548CF6BE91250C0B553B759894CDE72556D3EACE975B2A5B54D1ED706F650061B39005DAA4B7699D04C9A1F88E7845C40B27B0181C0CDC7D0252CE368B0AFBC015E2B99A1E41CCB98B8F7E5FADA1EFDE46C46CBE490A992A0B590CD887B4D1DFB24E5FF2CF89017E37AB18FBE8611C481B8397287AF9FD15EB14DB28F76E7671FF8049BB4B1183EA55C6DA24AE8639BC0CF477617E551A075A6636F78E5ACE03F44265F6BBAEAD32C4937BBE33793573C5DED515A32BEF24B96E93B2B7A7B36D62D2FF832362DA39B6497FC579426E96DDDB3B1520FC9E6D3F1504542920D1B2B8C7F3665926604DB67B746BDDE04697FFD5692CA0E4E82A52C1EA1E176789BE589C50152730D7E0A2BFA1FE5299A5A468FDC500BBAC6707AC102544D9D1D46C6A1B7B6427877AD259DFBEB187D1BE9D89A2370064F98DA9FF6AB037BD27D91F69132E7D47A61C9EEDA875BB6B98B60EF1CD050977B683D9A49F3D4F19CAEFEFA363F7233D52A92D670A988B1F5424E4A17C4ECAEFD48E284BBE7E43EF4D98DED6F7351DADE65756E77C9F6F4563799CD6DAEF2905A5C67745FDF71D71159820295F4D98D6D6E73515ADD65756EF731AD96B35D189DDC7EB598B91F726E527F9422E3E2E2FA84EF181B57059C627CBC7192BE8BF0B83DB8A54C8573FB775A08C9D5311C8773C1D9F3047A2FE11EE9DF0FD2A771EE51AC9397055E60EF3D633784B7C54E11D6DFD30667085C075BFFA808262E973C6DF48EA5719427D90823AD89B88733541735586F9652AF20FB58316FC8C764EF132C2CA3D810F8F2FF6064C1B007AF540E825070E1EDD9B59801A58C6BE080B855393288A0F5C41A6EA01FA0AA4FA161B3B2AEA0A1803811E3F980B9D7907994DDD260E6B8F327173F457BB5BC57F963A07D0C43B418B00BF3D8132D26E06083BC00DD7E16E337B55141CB80BC6D8ED7EEB658768EFDEDF4B88F62AE87AC709B0C753129F7D7460BD1F6DD7CE48439A645DC7CAD0CC65D56B25D00ABB1F4896AEDCC19FFE4957DBE168DE68283A518EDFAD551486BFDA3CD69105740DF6323F80DD49EF48301B67F182AA8D57AAAD656208B6B0BEBA1820F5755297D20196A219C433F560567F3F40AC1B67606D830390DCDB666D67A602F31EA80988012B729B42F788A7EE10AC232A11C43D57E1D843E3E79EC757E37493709C5A170394859CB440F523635F690D20F516A19C003947A2E2F935418B7D606C3A76686ECA79C477399D18CAE9B82F48B3FA2E1B6DCF8B16435F426CC1D1FE362DC790633B5D6B0DC3635F0581CABD9DAD6C0211BD4C02ED5D0C03ECBA8E593F01DBAD9FABEE0BDAD9FC6D67B1DD33D444911D04A4BD6379C9D56416DB6E6643BCDFB0EB7B2524A5F87DC3E39499F4194F4517E55D340C7CF8C97B9FFC2A6F9C2C686D944488D839DF64120B0F4839DB8DE71C69F58F81E885E402487895CAFF3DDDF999C41CBD53D933C39D86EDD10E265CD8CEE1D2EF3DF0E502FA359A32BA6EB6BA68CBA2133E6769DE1A9E12B8F45181ECA42566B41D62BDE312DB39EC36C15CA32EB4DF851B347236299396488005FD833FB5F2B4402CD136DBBCC7B89B192318501B41F1BB8763E3730EE5C33E1240176143A7498DBDB109B83DE41EF13775287B08EFBD6AB2AE1DED384EABA77F8E670F84AB663B7596A62CA9828503FC2F9536FD4D299BA82B2674CC620A5DA3347E229FA3D3D4BA45C3755D758CF2C59351FCE967F2A6F7974C8DFB40D1C62507A29D411110A1887A3CF47198B217388F34ABE2C824AF1FBB349A463BFD77C7ECDD976FCF1DFF4B88F9368F409A5BB2C1F29A4B77B41CEC6F48E611069C2471370C358963CB571D68F5CD08CB953778C7BCA41EC1AA11BBA119CE0040CC49F8564B19D76F1E6C1343A2E821FA10761B444AD8D7A8E914BAA56B35E93C3FDE2099D08788FD322925616DE734173579BCE3EE47A5F25DAF07132855CA6E2EBDBEC12AE52360F5B1FB0A7362357A01629E7B9F9DC1CAC7E5B7571B2CD3E9B688FF89F41836AEDD8C2E757DB7107CFAC2A69FA395535833BE54BAF7B84F065181BB085403A40EC0264729EBB892480603C5F4B35D0FE8D3D9B4ABC7815F8B4AABE96A29E6F75EC9E71421FE180583A60A4ECA45F20ED3E44C74BA34DB165A6F8F6C899D7BA4F2C3BB759AFEE84D45EC26DB2B1D1273E99664EADEEA4C449557764BAE4310191BDF9F6A28BC9D76E29627382E35149B0651D5EFAEF64689892A41950357D942BDEB7D1ED3B6D8B2DF39DBEF5F83EDF2EF05DBEDE4789F16B9884CAF4378ED6EAAFD92BFE1015C51F591EFF6754DC8577F9D4CAEEB294BD3FEE6F98C9BDB45A3B3F7BBBD0458743CED771797460BB5D122FB07F53B0ED318DB3E51AD06F9B3D5AE2A05457F9E3E9AF4C86DB29AB6DD0CB6A3F3CDFB3E192B827BBEA15E3CE2D9F40AECA687F98F31B0FD6838F7F646FB8679EE5AFD3AAD468793F679B4FD9B17C9DC655A0E5B772A3C75D88028234E7C566C38AE20D1F7316BFCC8E6929A08772350AF5655EEEA204A13AECFC912E8BEEC934299A83A524BBBA57A6B5BE837B85B54A75BF422DF47BF9623EA079C2521E6DA29067AAED53E2451E7C9354BBEB436DE1CFD93649CD90EBB2E8EA6B5250CDB5C961DF47E8840BB9F4860DE10FAC6D430ED7E65572CC0A6B73E8CDAA13D02635A9A302025D1CBB724FEB0FDEB4E478D7BF63F7A238BC67E583AEF48346EE9B9CCBE4BEE6A7079AD81FCEC8858725CB63EA92E5C9A39BDB277F79FA53143FF9E947C6D7B2B32F5F30431E6E27A152E512CBA57AF8AA4A47F95714C7A2AEE9F768770C5D95C31B6882F1777D01AD2F7A1F26735FB6B1FD21678569DF290C13C926B935D571FFAA98DBD37273F3BAF0E163A9B247E9EB9427DB6413B332E2858655B3F76B19199FA1D332FA476FBBC66FCD7A06577D76ACF457AB0CDB5A4103AD74771B0DB8022EF9685FA8F644C3FB42B5D8F5FB4275333F543741E32A9047B8BDD265E6E249F93B6FC675A6525A36F764257573EECAE7F1009D481CDAF5943B89435DF0DE515AD251723DA562F69CA6A9747EE238A3EF66DDA199C2770B55E9B89BBAE31E9984B837CCCF5186B9E9EA7A2A066FE7A45E1031348579407AF06AB4FF535510DEFDA9A4AEDFFB817D13306BD5211F3766A9604ED7DE95B810BEF75196BD88B2F633C7FB28DF2C718277CFCBEE9678EA7BCFD596733C4C1F3EFA94ECB23D2BF3812E78ECFBAFBCF096998E864DF73E7A7590FC90E57112858B59609554778F26ABA57ADD372AA27FB07C248DB3FF0556B5DF2CDF2705FF8A3F1F596E3E94F1789AEBC4C921036E6B8D7C2EC2EF366EF787F9066E9FCB7EEB76C81A9417C5F1368EEA2BE2F775A8AD13070D6CA134AAA05AE11C9A4A916CA3DC47B9F56E13BA58F6142775BF2B998B73C909100A8936F5CBB080D20B6DFDBBA6AE50EB0B9E22CEA6771EB755C9714E9CD7CAA41A91B87A8F7DD4275549B98B8A8133C84F8ADFD34F064EA19AC56ACA978009EC41D0C3C15E9F5EF32CAF1F37975876A90FB06EC1E4AC5C423D638F88AC8F966B7B4C46EFBF5632AE6B9AC372B4ACE8C8B57D1D1DF36A6A8972677153D081B93D874DF880D597B3A97D68CA81CDEE41AA35554ED19AA72407B0277E96E44427F189CF8AEDF8CC7C8CB626DF72FAC7384DAFC79371A7BA92082CBD7027BC0F96F134AEEDFAFD76E7D7E96031CB20139BAF6018F3667ACD6DF34E367D3327A96C820724AB065BED7E958764F5EB8CCE36BF0632F4E555CAE4D5F48FD34A1F9F9AA8DB7D2DC738D3EFF1BD2DF771AD7DEDB6D40DB8636EBA4FF928D4E143D3972AC0793CE8B54907FD2C3C0FCE5441712EF3509D5AF37803452A7EFF29407549A1046FB21D2994E04FD9F3E5D03C5439DD36CB97439AA493CA6F9FB79CAC8A4D56946C6235D5754CAAA8BA86A95595B2329B58535515932AAAAA606A3D850FE3F93A848DC9B6B9846D2E1213789B7594F3759B959974FCCA7526D204DCCF45505D16F768A2FDFDC5DE7D140131D57B22C8CD07B1E60A9CCAC5072D1960EAD2F304395317FE3CDD699CA53B155298EABFD353B3A0E0AECE03C24B1771B8AFDB6C03A6F5546DF102647159BDBC288A6C93D4AD023F70ED4888DCE3D7697C067D5ADA998EBED9CD1068DF331F0E0ED7E4C001CA5BC971A029975C55FFD10F55E9075BE4DA1E3E78A057C851CEF24AB95145E551F06F28494BFD93A85E533B443B2735285288D35E358A7D7D6ACA2B76606985052725511A229D9AD25BD457AC98019BFA2E2F04EC5920C9E7E56D96278383D4FB4CACE87FE4CB7E14314401204CD5B224F078D40DE0167249E5CAFF25106C1D153407801DF5466952755245DC705B1ACFC3DE822FA06D128C88EE8BF842DA5AFB2A304DD5D19CA0A66A8E8AEA41DE62A8E6AD2E93347385B2B91884DFB6848BCB60A9644998D2FA3F0336693AA234A493B4181479FD512C7C135588298DABCB5483C9C3A042280B815229E6024E4A8D0042A14E4D03510795CC80530775515AA38A5B0CB407F0DD730C34606E08987D461D926A2F7F495FB11D2BD9D98B4D59C7675F46C5268AF5852E5F4CC66E0D03F02B70A14D825AA38666C0A9511194FA0701CB6152796E1C1D74ECED710187F543F574AB883D574E81762804C1BD9A033B70E749A8A98A2E0718E34BA3E858D3DE7F16465E7EE9C80155B4074E919ABA43D1D3A08DA28439B04751110989F8FBC8F343B1BFF44543867E0D8C083ECBD2D9F2A6B6508BE1E18C19E0A7F67F76DCA9AA3901C0A16FC56360B0BE074FF1964C68B3BF4C4F4475208CD93A3C03CA6C2AA13441260A5F2684A8BEB181C6EAD00737849564C7D7ECB007833EDDA459B0A9C27B48C72803887344B945F31025509A20BE87B608821402716CA03136F161987B061C3A7A100E724128405C3C098AE0EE510610A490A163075601A56294BF664ED47426C336C21ADF7B10DC688FF4586D59B81D5EA467334246E9FD788337C77C05D196A2938B91C3543C4120B08BBAED6019DFF59B6D0A33F473CE69CCA00CD254A63C70B9AC611230613523D06B0F610C14446CEB0FDC71864AEFE59CC64AD7C449182CE5B10BDB80AB2F5F044191F25E06E21EB55CC693BA4772F766848FAC82D5BB47079447130D08D94935E580774B24E910F2B49271520FE505DC98317679C6B9CFAA1C52DC497A5F7A61E0D9039D065ED460505BCEA9C2BBB708ACBCE298CBE349A7AEB54D56078DA536CC2478D0F97109280DEF4669FD9B7116D47470522E54F3FC956D9C95B7B08260477E410BF19F9ABB1B93BA4F52DF66C48DD4FFD53B4FF627E3B1F176783FDE3A0D9970457F75DE67232F9CCD22EB838289915321596794B674C216B3694A6FACD76290FCD3E0D17405466DF05CD85BE0EA8B452B2781339DAC16C38081B976187D6CD84DE0C2096FE9B00A348FA27D9C014DA81A28754B1CCD8B00096179C506DD46F93A8CBCCC074C87958DC2D80EDA40A0327775066499354169804603BED09CD81CA188D9976C77ACEF1B0E7F1A3C7F4B39788E548BB84D97E60A17B36F444DCC32779254448A6248E7B9D684CEEE272768F68566C1E550DB9A40A9E96019446ACA21C35110B28263827D3F48E6D2526E824383703D20206DF00F7E80D0A883196049D412A5252B384E28F6C6B2DED0B33A21CF72300390BE82B3D1789F67469AFB0A6455E06AE3921470755927306BBD68005948B039388ED4EECD8A235501278223E8A2A7FD2C99A1104C8E60BD556BA6463054B7024B4651C70C58A4A889D28C41CE8297CDF588F62DDBDC19308996002F965BA161BC5B8E56B5EC8D729B0628836F204377B84D6E53D0D8962C8340F19919076C408FC84C8945F08D9BA13EE115A8B960086860492C020A3A01402AEF3F6080C01E831800D0BD1D420719F6B0892A73D2ABBC70C7669857E1DED32AC6DF4D5AC886D9E0437843674ADBB52CC4EC9D5FD26C7900706993A5BD21805A18FC41010101F5CB170E660B7F9A0380B0FAA2CD34460CEBE71C760C5307A96EF8DD9B050D59FD608C8B69911E8599D488C9EFD42C85359B0E16B565A28A4EC0921908EA1D80A152D04F09428D195F3CE0AB3CA63217FC94FE2F0940453D270AC19A6DA1DF2C7182A25C741E482A752ECA0C44D7C9A230855576027095B9B21DCE1DDB0A4E487B4E3B7B3CE7A163AA32E6082F13557572D86C5EBDA021447EDE223C0295273606F9C0C333135D9F47BB3B3BC6246590762EB47754168197F63080DB99145A710884B627194C3824D6BAE4411537C55000637986818C5B37E50568D91228B61F74C68B4C8ED6250F3DDBBBBD2816BD4E412F8F3FE0151F0C0DA6277DF4FB89D0DD4413D60CAF01CD7FFB11EF2A6554475E81C43541A9BC2A35D33DC8D77533799992976079DB80EADFEC6BF504A4F6A818EF4CFBAE58D13E4CA5A2A11278C54AC4389E9FBDEE9F8242CD9B863059A6E2DE690295748B346895A2898432D95AA93FDDA3B754CF43952A1C92C0C50A992C72FB672D34617D8AB565C0F90DA069402EDB08A9AF1BE8C3A3E6B048341C7CD2641BF25A6A114E0A6A5285348B1481675C9322A4D9A4D404E8BA80FA675B59999C551722A753A475112BB3AC2E97753475BF1A18463D130D2506D3A5E5A049C425D9BFB28E6150FFB2BA148B84F69D3FAD7C7FF8D4525E23C78484010C9A56A32EB09201265D487568604BA0656E60CB6145F80E5BB60FF03B6CD31C1AD7505398DBD6784816A1068492A129DFA8D4E4C8C91659C2C9294D90906691229F63D004C9C92459A814BA93A06E48E29E829AD3D642581CA9ACB64F050054C961910844D13499401E8B541BE041B00B9E2BE202EAEF849E0985C0077CCD2F8B1AE28EE8DBA27D5F35FF5473E3C9B2BBD59320DBEA2C5FC8FAA2E892FAC025A455AFC731651DB83E8F296ADAE63FFBD504E89DE0FE8DD0BCF5294693EADDDE718435427EC911523EEA777BD63597FA2D6F06023A77796550EA3CF19D41A1C7C8B2CB45EA5C7AA43C780728D3F99D3C79DBDCE1A53C5101E695A27315808E294B5C7725C30FB4016A25BCE426F5D2FC969BD02F74B1491007A8095F017B284779290C528BE93131B907C87362A22A8065B35106D07F7CEDEED17FE3C3579036E82F65C9FD22BD9525F6D2141B70100D29500C240456617FB3CFAA3BF80EA0A167DAFDBF00DAD22EF90932E9F12B77A5A18F0E016AA33D502475D2FA4411C59CD02462F842C35A1EDE9EFA6A0EE4D4195FD691FD29EC6D1D712A8263426639388602284179F8055081E96918A9E1C8E33042B3DB5097A1F3C85B30820C28DC154C0BFDF8E06A00DF3A01FBA0BE76E2A508F571133B987CBE04E83D0E70CD6E7BB743594D1B5EEE90D6E76830D12E6F96AF436AA1011BD87313F0D0020F4EF86104785F82A6DE112AE922B9B836A0C712C0F62BCF2578E940791D0131185DA38378FF30B53FB20220BC03A0B9EDE6970014D7150C77134582A0310512C728CCE8CA5988EB91FE185D3847DDCC6B5884D6E11F1242BB0E7E073AF1BAD7E7A4F3AC53543A42116D281A574293C1DEF23ADFB8CE37222CA6A46DF06805D879AE01A53892634BBDA4D363DB91EF2878E6D51046CF6C5728611BC2C6E53C4E79A62D07DB26B7BBA2747E614045161262A937380DB1D00FAC031649B3680421CA05D442A1D4957A6421D515BA65DAE3A588043415504536A257F02B73E086553E0F1A3BAC040ADB0113A71A66819D919E94A65084CED4D6579DD034A82A7506D349F56863D53486C308971E901896F9BEC388E098F94A83D3488DD4263E3FD85823D1AEE13384BB9A960EBBF69C864605C1CC8748A734EEC3110AD2C80E6DFEB1D726BA81980FDC37A712F929DBD7042A3FB75D40BAFC99F18593CA41DBB834063A7967D5CA41E7B4674D943DDB5EAD85128DA6449444CDD65B88462DA83A21DE34A102FC849FBB26152E2F407326B62FA92308DF97D070F82CA04908D07BE3B1C42050322883CA63651B618392C6C3673EE5E9B44A1080CCDC4BF2F0A3EC4B622780239B1629A6933A9673A461205573041101A5F30959475C62140A0B2689426829FD751437340D828438B68EAA943841B5A872E048C157F3C9E130FA53F859887A34B1BA58BB8CF0BA84D52B42E432D929162B9988F564B4536C974C4112E074342DBE3BCD395D8006C3AA48802DC3D03B992F2380BA64820C41A0FDD8BEBB8288440E80CE7C2820A45E3B9240381CA5F7A966AE1089817380A2644ADC98C051104C9973C59081ABF280BA6C17EAA5BE18AED40B7D0077EF6C7202EF085E5E3482FADBDE7DDAE5C5D5E68EEDA3F687CB0B9E65C30EE531DABDCB62B62BBA8477D1E190A4DB6228D9FE7276758836BC172FFFF5EAFCECEB7E9716CFCFEFCAF2F0ECE2A2A845170FF6C926CF8AECB6E476727F11C5D9C5E3870FFFEDE2D1A38B7D23E36223E959BD9BDED754724764CB94D4EAD27ACCDE247951BE8ACAE8262AF800BC8CF740B6F66EBBACB65EC75D35C8F5757D00BBBB4C5DC1EAEFF61A7D74887863B242BFE2AE881914F986F76DCFC7B8EE26337D609A082EE46A13EDA2BC631480182A5E721BB44F09D415B8BCECA68E3C75365D94A824E9322F2F947EAAFABCD014AAC05B1D28D230CAF39DDF181A651006D0521ED3B63A686E639566FB9B9CC912BADF1C469C03AE8CF23FD88D32DCC2EF7469DC2B63992CA8FD892EA38CE22F49519D0811C50CBFD225EDA2521652FFE0503EDD2AE5AB1FE8E5E3843B088D57204A117E76684BB65514DBFC4297309CC3517127A7ACE6CB262D57289FB75D10E11BA708C1543F50FD896AC709000D90EA1D7B0951E81A0297546DF4C3D2E414BAC47D92F27F165C43CAD4212538C88BBE22F2C40407DDB16273E443AB7C47C2CF74599F8FEC2ECAD5860DBF3A496205FF21CA3559FDEF2E9342926E76C76FDABCD0FF4C9715716F8A2F8112A561C2CF7459AC103661A48F404CA0CB2B5815FA8B6E925DF25F519AA4B775AB64D1581E0793996C3E1D0F95DF936C148D2A494E28AC2F76AAD640FCDDED2B1EC2A1AA4C3DD54DB218D8D725CBA9AB9936F48BE39E4EA14D0EC531B4CB588373B8F448992E053B0D152AC865AC0C42FEC483D55D5AF71B21A4346158D0927FE2B1A05DA7A77D395649A44F8720659AF10AE75AD727496431ED4F2E6E8E4C2BA0B50B485F0DAA54FE04CFC596590A65A56593F027FEF25D6E6950468B2C8F306E0EB2B031E8AE2EA82329FEEE30A2C77D141F77F5969E34AAC2EF4ED2F8220290D5FEEA24095EB14809CBC4991AC4DF6525DB419F429B304F44198F85894F46CB3131D363D2B844E5B95F51A4E525605C66B3FBAFC5DAFA5F5763538693BF7E36042D4FB01986B26BB0F2285E0E0A480EAE91D88647078AC40E29AB41C8C067E38710B43C012186B26B4648CD12A40D6FF7E37A46B6623BF21C54A028653CC1626B18CAA58640E2A2F11C0B930CCAA098CBAF6174FE0C9B7CD556449E1C006962C21C8ED292DF427B6232C097004B72FD1E3029E11CBFE9831BD5230FEA975682A18DC516B6DA513ADF15AD4D1069296B17328D51FC9ECC195F2AB2DB2C55F65B875F975CF1F99E9C5A36EE33F2AC9A450A3DC6E37E522D6C64A70ECC5EF306E66C0BC56C8724A7A84C9CA83BFAFD8F4E72EE32ED68C0F0ABC369AAEE0CADAA3429C13122D1CF6AE00425A53A4A16EEE883B295F4B57D5BE3BE29FF6F69AE99A5FE30CA3C4A8B0830F07AAA4B3CA3BA47A446329ADF1CDAC7BD9A63AE7ECDDD8F0EB19996E6500BE409BFCF716A0E6D9F40B1A7B5514973911A27DBEC73AECAEB7E5DCDD786935E92F62BE1D2943D4AAC24A6D18EC24B1D23F177B7987F7DC0FF36D90067EE8064BAEC6ACF204EAA529112B49753568301ECE2050501DD5B46EE08404B627A7D3BCADEBEDE4789321CCD2F7411959EAABF5400B23CAD7FA54BFA1015C51F591EFF6754DCA92682BB4A51C1522723FBE12E4BD9FBE3FE86A9E7B43DBCFB4011D73CD9B33C3AB01D5F0F68B3919CE672D0707B4CE30C16AB257AACB31E210B2DED354E92B4C788B4C7CBAEB6EA6FE165754B22DF336DCEAB7F6EF6015DBF902BB639E6D5075E46FB833A384D52D12479619BD0641FC07FFC237BC31D9B2C7F9D46373B557AF947765BA7B22E952EF9E76CF3293B96AFD3985B4BF65BB9D1C6AF4A66691CF3E46395EC211B68732FD8B9C52F361B56146FF8B8B3F865C6D709FA5E7D95232B6EA3FA235BD3DD238040DC6F52D3DFD4739FDE0832A699E8AA0A55097E4E52DDEC4A3FFA61636731BF47BBA322E74BB4832F102D7675CDC4F14DBBB8864AA0B8C4A6D233B9C5F534CFF67CB95868016A29C9612994DC2AE6BAFAE17442B0531C99E12A6029B8C296531C161DDB6413B3921BE548758B942407172ECB371CA8D13FD4CB16C2EFABF97A0132F8F1C6BF79AF749CF14764E0D33ACFFEA13A6511ABCEFC01273CC7E575A2FECEBEC9D23E553F4C39AD2C783A06E354A79E8E01CB53362AF1B27F5E033EC999C39926851518338C1EDFD596D54FBE8E3365B088E91DD1AA5E55525EB177ACCAF08CDC0D1CB10DE8BEFF376EEF621FE51BC5BAB43F39C8A8E84E144FA5FBCDA5256592F3AE6BADE97FA6CBFA94ECB23D2B73F54CB9F8BB8343B68FB64C092B77BFB9EEE570872B4E22D51910533C2456FB9F88C826C9ED6A7854707F50D39D9C32FD7900B4D72CDF577C15ECF391E57A3C524B75BB988BEE0C6B89AB3156D20B047E06CB248260B4CCC5A7315C2771027560F5F51B17B43C61500C65A719116E0FB96D902574BF399CCCE32D8E2B1A04E568DEF0B39BACBBA8500FE8093F4F79627021CC4974C07EB033892020CF5C1C075FCB12AD62B0FF7989E39DDBA33A5B37BFB849B8AE4F19AB3894531C66D423D7C97574CC2B83ABB29B68892B03E628487A8371B643A62CDD1EB967A8AC48FB5F57331818D3B3DFE810A511868B2C69FA4FBF661CD7E0D0FDB89A911C316C9E63E436206BB8CA72CC95F322F50FAB1942952EDC37DA6994428A795A244C33C680BBE7ECEA016E9EB38B77F872686EAF2B4BCAE1672759D5ED754D52F3A3939CF6E2BA26AAFFDDE52C635132A88F5282A33CBD9FC2CF8EB2C0BECA290EB6839519D459F17737697A57875FDD24811D9512BEC3A589CEA2EE67E9AC7208B68E20631A6B479D8BA69D1165DE7BFDB4B49ABA1A0C85D84319B97FE2B67732EE0850F5DF5504B9342274354B5F7BFB4BFFEF9E08BD252197D8D1EB7E575CE7757F8B96105D65256FB29C9F753BE0CFCFDF7DBBFABC7B50A53FA8FF7C591F421F72BC8BD2E49615E5C7EC134B9F9F3F7DF0BFCECF5EEC92A868E8EA5BBEF5679B6351F2E5615ADDD96CC8EC0904EC8F9E5404EC2CDE5FA8C5DD69DC2B294511EF0012F76A9894183A1C64BDFC3BFBA60E7507A35FD92D1487BF50065E9570A9861CC4C255C3B8D94A2A7DAB1A78F6368DD9D7E7E7FFA72EF8ECECEDFFBE16CAFE70F64BCE07E7D9D9C3B3FF7B7EF6FEB8DB55A71AABCB28BB4283B4DA066587B96945454B2F4A2AF3A3224844BD51C986D980A6611FC5AAFAAC6DCEDFAAA86954B2F84354962C4F07D3E3ACB4CE5A34757C89F2CD5D1514C287ED6DF15B9A7C3EF2A1FBC855590DD3BBE8EBCF2CDD9677CFCF1F3D7CE83E6C02DF79D38A9B2CDB398B69D9CE957EE06DD381A0CB1CA8CF838AAD0F30E0129FBAEBB03ED21054A270EDB8919B42821F3F7DEADED69A3D9DAC50924CF94698DA60820D1205C846486CD9E3BF585A46B62536AA369A41C15C78BB59194A3A1AEBAEE0284B3D709C37B517FBEA84795A3A0B9209D30D40FDC91D531277FAC8764ABCE9236509ACE98DA4986D927D75CBEC43159E296A2FE511476AE52FF2E4C7AEE669E05287A750522B4512F5116204FAF4115204E2F4115224C2F4113315C68E3E42A4C2893E42924886EE681A86A2A38C834E9DDEB6830BFF466D8B2A046B11C90BD018D73D1B240AA13788EE9F9A29CF67F1517B959CBA9FEAAE758436F75EED93A81D2427BF5F864D006F0BC1F8E9EA7C591FB865386F5D38DEA332A92279820FE7EEB24224E71E73952EC6A1A7F42590896CFCDE6A0E5FF38FB6353659E5449E709AF271FE28FB2088651D3FBEA1E8A8CF4F642257E1E02EAA25221F2F485D0D78CBD2E23784F00DC51996C8C871C93F3A0BF68CDE42F1259129C1115D62E1316B868DCC5DEED80AA9F428980FDC978E4DE80A4EB04E4198C74FD79198D9DC03683B7495FB988A83447DEE8A13A1F0145EC2012621FF5EC042095287464BCF85EE3AD44DB9494659A326FF5E06783DCE9F8169FC5ED923B6B34E71332FD45E9EC48EBE62972DD877035D5AA17D3D380B79D08DBDC91CBE1308A934C4EAC1CF7DD828C94FD77AFEA96DD7401F475DC6128F37CC6FCB801DCFD9CF63B906A1C61C553BEDD093C2931E3402DCB3A68F0F45B5A4E923054957E21DF52D941D1F0491F8D57DE64641C0F8D6288CEC3EED91444CF8A17E2F939DCEB31EF4CBEB68D7DDCFE4D05ADFF1C4853D382752B37B1C9B1B8A8F38340747A4D6709C0FD0974213EFA3334904B575A4A073CF39DF346B97715101CF3F433CEE347B807341D9ED8258D643DD43F1A0400068E3F12FF389FB8729F3C7075FD3808CEC73D876F074A6CF00347CD561E23E1EA743072AF8C59A20F2C7FBC75E28CB200FFC2281B991916B854C3EA8708D523EA874915D3E700C4E609A0FBAD5BB8E952C40523FEEECAD484DEFFFD9C044F4235AA673CF8F1006B0CD539D5D223224CEF9112D8558E6A95B99E4D9CE42D03EC7BC37C992669DAE51431A1FD414B5FCF123643ADCF243A8D9FFB49EAE4C261CF2CC4FCD2E6C10F85DDEAC0B76D049E68F1F618315D6F8119244BAF82081102F130FD0B013F7E870D6752037C8AA1ED824082D0ABC7EAA5B1F58E61A0C98D3C92280C0FDDECC3B99799A0F0FD8F9F9CE3B853B596A9E5D3C96F096D9C52AD1CB3CEAF42463310F6FD2C1ACEDA7FA7DF4DDF168525B760EAB36665B758DBB362DD97CD85D8F8E7C3EB0D481893EA4932C72D2BBFB54941A3AAEFAB0EA9059EB27DA165378EC27AA45A6B61FB923BE06AA9C83C682DF34445F577BADFEA14D7FD7CBD27E9BFF643B8953D2CF7BF56CFEB03A59450841FCE9CE251DD9BC69D5E361E804EAF991A32B10CF8F9534E3414C32A070DE772AA650AAF7A06768857A5AED0D642D0415F6C54FF8286D43623F22122473D78F10A4F1D5936539E272012B37C02AF8C9DE9E513ECCB23B20A30089C17D1CFF153C563033FBDAB9B2FA663B56DE969BC48E7B0ED71A7D82C5EF6ED6ECBE8695977587C121E069606F3FDD11945CAF6A7FDB5982E47279491028E0A75AE876D4F0D3C9EF99C527AA42E2909FB28E49152593CD4F5489C8403F6115932A4A22AB9FA88E552E732CCCF1A76B696D5395C7DA799263823A3BBD233A540153A004278B3FA963B8EE74068D96AB6E577FD53FFF30F26C2CA6F41745916D92BA7E101A16DAF4D7695CB753A5FE6E3B5BF1C43F5052DE719B9D1C76C986B7862B54D3DE2052AB5B94AA27CA821F3E78A0CBE6D8607905AA68F7324B8B328F129DE2FF435EB1691CA21DD83325371178D500F472D59457ECC0D20AEB58BF29751A9F82BDBCE8EB50BE079B462E2F04845880A3926B5EF7EB5856F43FAA2F4F8810D2D8392518E9A984111FA403945EA278285996FF2F81E064E6209D0652363E33A4569DD77559640D81115F6869FCC432B684E4D30617421AB83A74C94C8C8BA0AB236576845447AF2A8E73FF1B7D925B0B7240B6D855C145E4DD5E04282AE9A79DF855186685CA531A63358D8E1EA809B26103D227C18F91AB741A1C59F58F540B71C02E02A843CF0CD7DF0532189C3EB734C2C2AF2A6CD42EFD92BE623B56B2B3179BE6A1A69751B189F44722ABB5428CB562A026145B21FC3A09BA0E30C7DD34B842D81791CA0E1237E03238AA68E7FA7618105471C849E0A97FA09B1B4708861A7C8DFA6E9A71770359CF11B8CC904B7C1BD212D5644224823B690CE514074800DC5FA8E02E7D1A98E0EC7D13E1C5467B862107E7399B1F3A2D854970CC58164C38CFB6588321D7F7012122DDF83A81345C60AE1B5220CC99DEBE03D9ECD0511908276E1E42483343AA50BE96BE4CC8A6A5BDB19A978E32455AB574BFD1F1D0313101D663AA500BC4F5820C88F15E88B3B5205529D2162D8280AECFF56D727CFC3B9A1571E0FADFE8E3AFDF5F170502A9936002E48C41066824162C17F6914ACD409C11153053527058385897701B4633A2209C119A634E1068BDECF382403220EF260ABFFBB89C734E11185182D7084D334D286C6DCB1A05945822BC610804AFD51B88A0109C110B3543C1AC6E43C38980B90D6DEAF7E4360024106B4545CF44400F75A9B4107DA8B2FDD5C556781D6D0918FA064818BC46CAC16CB89E79394884A40B83C41ED40A878EF9DD8A4510E1E254AC000B5DAF115D859F491C117592CE4448E0CD8881AAF1B37A12F58155CC916812BF273F423F9FBB564474CF13505FF9F4B2F2336E7B84B3222EE67DD13D0FFC618B6530643D181D1639E059682DEDFB4189D319E8C5B1D13372581D50701CB1019C081781661DA7215A001512D5CA22B090C85ABA3F706C48C42BE278CA09748C38812D102A70F6986990E15497C6C0B3D04CA2BE9A763DFC69F05881D7D6E4AF5E4F3E257B627B4C6E1AFCF85816FDD5A4B5E0A8FBE91E44A70122E5B1AB858FF3F4E82199A380A77A4683F214CFF778427505877C44C458FC5D47909CE4E9C19951336615BD2AF0B461A1592C8C43B4EF1451E112015C0106801B3C849321E3EF3C9D9E6DF1BDEBB4A895191ABDE0A53DADE9D7F5339738BE46DFC83C910B7B7E636A20949BE1E69EA1F265B0D433C01A1CE449013550D08A32855FBF3BF020A4BBEB844CCF745AFD1F0E91965F531CC2EE273A1424F2585DD4A497AF2082506444460E3F4E918BD68773E22E64356C7098D4622C099325ED86337096361D153D295758CF4A815B8F8A6D541AC9FA070F120A857016049D9A671A7BA211A82283148A8BC244B58B550DD3E52E6856788316322AEB43D092A6660CAAD6E7E336ACB80B014BA5E4954FD72969DF1D908C84C4A703A0FA7AF0B5F57EF0B4405A0D51C1A280F2E42C5818543229A5C3B9BD09682947A3F484A9292780EEECE8A9C8874DF70E830346673B16C502A9135D469C192B169267A4529D997811C8A81CAC8E7BE2A3A86B4F61877C0A8EDAA977CC97A7C8D550653F0C381992963814B8286A4E8C4E59643FBFAEAE59E0189188D2A17B27D09D93B55F66C1D9DF91215BE2464B9E812FF84E0291D775F3789992976079DB829759CCDE247951BE8ACAE8262A744A8DAAD4152B1113747EF6BA278647ADCAD5E68EEDA3E7E7F14D652E1A92793D970627B966C5C9D1AA55D2A13A952C960A214F5CAB15CA04550DE5B37558672CD73BADE7013BAE67A3562EEC23E3B50B998CD50BF92CF5F754C85AA57D0A54539F68ED1EB04F0EF40FC8057710C86883974ADBAB634BCD01024BCD64A9D670F2446B80212FD41443764BA384B3585A238434A85221D95289C033AA5522A4419508C9B64A6A4A545D7EFD3328BA4EB1499549E974F1723A588F9CC5A5C22E9A65AEB6CB65ADBCCB6805AABE160110AA6782A1A9E7A37D2886894ECB61F828C8D35C7FB70FABCE588DDDF075EC55BAB1EB524003D7255AC4F7672135F17D0A24BE4FB4880788D8B48A803C708FEA24ABD321F0F9002E87900A3B1C420687BEB56C31C6BEB579609B582711EC614B2E00DAC3360DB3876DB243AF1A6FDFD8A9268B0122D779F52AADA552C3376BFE58C95FA97C954EAB454E866A9273586A138E6369550969503D42B2A512F9F886568F9C0C5525E720D586D663AA81EEB8AB1BC5B8F7AEE634BAF06A665B57E1BAF18A4852B5CD4BE01B5672C05FB292C9522D106ED62A06F2405503D988C6C46248702302190F61B98C2C36F557CCCE8442D0F2D3F2EE9969C7A0EFB365B96A89F20962AC2BED0B590514F550DFEA8214E5F5CE97AC326C65DCA8CDB6D8B56EC709C2088B9911EAB33E4865D29FDB6B56B002B5E5A7AC417459B9B80A2DAF2E017A7379A749EA9E128AA8FB84C41916570BE58D214037CE4F13C91D8523194D2FCDE10905956850A685A53DCAE2AE32F8151D404984E776E413236ABCA1EE041A4A90CA6A0191BA2C1EEBF0E8B6F2E80BD461D3BB30725785A847D34B20AA3146393E1D343E71027597FE268ADC152838D374C71473C165C83EB82E0971B1C7AAA8BF3967D50D7CC72EB852ACA1CA5A1E3DEAE8AE20F4890A4045B4E72CC67CE52114ECE3ADA86F31404E89F1BD06D9CACB11A8C6B2C3E125080DD0D807E8A4F2DC00D045D383045243951858DD5024C085EE9A4AC1AD5A02901AACD3BDFAF15E234CF101BAED80071FF042A4F1E0F2CD462EAF2CDAB4B860BB6443037E0B80596A8D616C7192EF10E3EBAEAA115D6E79BF0DBD8598C1837FBF520057FB7E7F06E3B37EAE2B4C6B8DB8AF040E6CCD4B9342C4BD9706467F43C43546A9C1E8C258E89D83757C9E6F5B680B8E7594713700DC1D5534A2AB557DC64FBAC930ED172DC61CB50FBA491CDD613BBF2CA00447525A5FA8AECC33C76854ED0A22846447AA058CC2DAF681DD55A0B385029DB7508A4ACD07DB8D3578C18E237C9840EF29CC995247A07DBDBA17A6FD3A7F257A01DFCCFA087E000E4491CAB8626730DAA1B59DAA581025465A439A96101AC4EF464536CA3E63948370A32158B063B492472A07B7AF360EBB802A587ACA0518D78C0A8179D98229C4C1A9F3DAA233508B81BB72542AB2D05B1E2B43094E9805ED3BD1D8B5C26EABAD60CFC9C20445D314CA1D35A1BAB49348B510FC9091BB6A14C6234015264E24A9B1F219A3BAA5F00922A014B007633CDF140403864E535980261CFBB914A313D7402030B3DBC80D170E60350D060E58C18A834F90C9DAB31C070B838C9A9A85880B9DC6654254AC4E551DDD084D592039C984EA428EEDB5B133F359BC30EA51C834886A3251704CA9AE45F6C5AD7411D6F37F4E51B81027001739C606F022583503D0270457067A48B596633F77EAAE0AE27D7F403B3E4C015267479DFD5C7C956DB8D24E511625A6174E4153C7F6803BDB80126C37BBC12D0C74FB02DABA986513E4F2A291D3DF48EED32E2F9AB3DBED0FFC9FDCC6475BF62E8BD9AEA87FBDBCF8955BFE64CF9A7FBD6245B21D445C729929DB54750E42BB3C6FD3DBACBB89ADB4A8CBD225B7C3F28E957C3A2EA3177999DC7203CA9337AC2892747B7EF67BB43BF22CAFF7372C7E9BFE722C0FC7927799ED6F76DF44655417BA4DF55F5E686DBEFCE550FDAB08D185DFEB804AC97E49FFCAE11EF7ED7E13ED0A65D03011D54DF1BF71D72D6FC6B2CCAB43C2DF7A49EFB999A2096AD5D75F70FFC81D9E1D1756FC925E455F984FDB38FC7E66DB68F3ED4375803066392EC43E10B2DA2F5F25D1368FF6452B6328CFFFC9311CEFBFFEFBFF07B72B1E817BAC0200, 
'6.1.3-40302');