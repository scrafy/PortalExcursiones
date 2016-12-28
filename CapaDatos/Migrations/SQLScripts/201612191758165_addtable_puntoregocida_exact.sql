﻿use portalexcursiones;

create table `puntorecogida_exact` (`punto_id` int unsigned not null ,`exact_id` int unsigned not null ,`nota` text,primary key ( `punto_id`,`exact_id`) ) engine=InnoDb auto_increment=0;
CREATE index  `IX_punto_id` on `puntorecogida_exact` (`punto_id` DESC) using HASH;
CREATE index  `IX_exact_id` on `puntorecogida_exact` (`exact_id` DESC) using HASH;
alter table `puntorecogida_exact` add constraint `FK_puntorecogida_exact_puntorecogida_punto_id`  foreign key (`punto_id`) references `puntorecogida` ( `id`);
alter table `puntorecogida_exact` add constraint `FK_puntorecogida_exact_excursionactividad_exact_id`  foreign key (`exact_id`) references `excursionactividad` ( `exact_id`);
INSERT INTO `__MigrationHistory`(
`MigrationId`, 
`ContextKey`, 
`Model`, 
`ProductVersion`) VALUES (
'201612191758165_addtable_puntoregocida_exact', 
'CapaDatos.Migrations.Configuration', 
0x1F8B0800000000000400ED7DDB8EDCB892EDFB00F30F897A1CF4B87C69F7D9639467E0EDCB1E63B7DD4697BB71DE0A2A8955A5ED4C292D29DDF61C9C2F3B0FF349F30B87BAF3124106294ACA74171A70578A64900C2E0683B7C5FFF97FFF7DF11F5F77DBCD175694699E3D3F7BF4E0E1D98665719EA4D9EDF3B34375F3AF7F39FB8F7FFFE77FBA789DECBE6E7EEFE33DA9E3F19459F9FCECAEAAF6CFCECFCBF88EEDA2F2C12E8D8BBCCC6FAA0771BE3B8F92FCFCF1C387FF76FEE8D139E322CEB8ACCDE6E2D74356A53BD6FCE03F5FE659CCF6D521DABECB13B62DBBEF3CE4B291BA791FED58B98F62F6FCEC65B48F5E45555E9E6D5E6CD38817E0926D6FCE365196E55554F1E23DFBAD6497559167B7977BFE21DA7EFCB6673CDE4DB42D5957EC6763746A0D1E3EAE6B703E26EC45C587B2CA778E021F3DE95472AE26F752ECD9A032AEB4D75CB9D5B7BAD68DE29E9F45DBCF8774CB8A2FEC2E8D0FDBFC6CA366FAECE5B6A81308FA7D508B49A284950FD4F43F6C86583F0CA0E0D8A9FFE361876D7528D8F38C1DAA22DAFEB0F970B8DEA6F1DFD9B78FF927963DCF0EDBAD585E5E621E267DE09F3E14F99E15D5B75FD98D528BAB3439DB9CCB02CE5509437A28715BD3B759F5D38F679BF7BC38D1F5960D0011B47259E505FB1BCB5811552CF91055152B78FBBECF33A61541C930BF2EB9C2A2988B61659F258725EF58679B77D1D79F59765BDD3D3FFBE9E9D3274FCF366FD2AF2CE9BF7505F92D4B794F1C0BA664F83EFA92DE36E554B28EF3EC26BD3D144DE6679B5FD9B68955DEA5FBB6B73C90625CE9F07853E4BB5FF3AD2A4B8B79F5312A6E59C5AB9793A25FE6872276A849C1E2FC9683B04CD8977C7BE89509D448CB0A493AD68C966228725F4362B25E31D49AF6E288B513A21B6A34C4B2D7628C0A95FCE27CB429464BA340CFCDCC4889D7B1313EA6258445799BB0469536AB92E5BBEB8219CCC9A3870F69C6442BA4C59C71705451F107BBEE33FF6BCE911465CE92BEA409CB43D4C09C4D15255FD2322FE6CF89F75643264FE7698F6D9DCDE299E6B7415ACE31DB7D917F612CC9C5C11BCAFEF15F2CD957C581903B6AA3F57172CEA15535D9C491985A19F6353E3446358AABF44B6D8109D581126115D2E35AAA042470ADD44D5E2123A89C55170F2B7A136C296D1BC7B5800394C1428E4097F292FD163492E68CE131213F8C3CC64320701BE87509EB8CF6EC2B2F80D774624CB9C45C22191CAA21B7473F399BD15D9AF19F25D77A395150F4358C208E85F8C01D9F615079C5E274176DCF361FB8579D766B12DCAA5FC6512DF4B14DE0E703BB8B8A28D07CCBB1363C7356F20F91C9E7982FFB2C4FB3787BF866F20EE7CB3DCA2AC66740E93A7567E56052A6BAA7259FCE6555749D6ED3FF8AB234BB696A3655EA3E8D3F1DF6F58A401AB3A9C278B7A9D22C27981F8B8B9CEEF3416F82B4BF7EAB4869C771DA92165FA9E0A6F0362F528B0FA2C61A5D05560E1FE551929A465FC1A026745DCB18040B503555766C1987DADA12E1D5B5A674AEAFE32AD444DFD2BC12657046A9F5E97A1D5893BE47DA5BCA1C53AB8525BA6B1D6E587C17C10E32A0A13EF6587A3492E62CE3315D5DE63449B967492EF410DD58EA2E16A5D87D54E772576C472F751BD95CE63A0EA9C44D44F7A90977B990D91390C910DD58E62E16A5D47D54E7721FB27A26D62FC392CBAF2633D7438E4DAA8F9264DABAAA3E503AAEADAA024E717DB5752EBE8BE555FBBA8C32842CED1769AB1FAE0ED5349C0B4E9227D00709F748FF7E903E8F538C629DEC4E7B817DF028DD10DE253B45587F4F1B6421701D6CDEA0229838CDF0B4D15B96255191E6138CB426E2B85680C1C8CD04E6D8D78ABB4276EBA93CF9C774E7B3A05645896171C8BF73C882616F5DC91C049CE0AEDBA36BF36A4A1AD7C93571476DE2445BAB89754A4E3F6CD39C58C246605D41630271D0C5E301E3AC21F2241BA5C1CC71834A4E7E8A43EDFA1EE48F81D6FA0D2BAA805D58C69E68F37F071BE405E8AE5B4CDF7B4505AD03F2AE385E9BB062DA2586D6ECB08B12AE87BC741B0C753119F7CD260BD1F6A67CE42469C162716F19E8C88F9FFA1D50050DC65D5EB16D00ABB1F6E95BED6814EFF2CA5E5887C645FC35A28F19DAB406710BF43D29820F41ADC9D03060F9C766834AAD876A6505A278FA5D60F97A136730FF6371AD91B5D2DB534C3A2924E8DE6D901A129EA2E775048B1CA15C2FD52AEC853A3E79EC759033CDE2943264BB9CA86B64A227EADA1C0748E9A7E9B408E0493A3D966B476F77848C1B55A33951234356498EA339A56844D72D36FA350CD11C5AEE5F58A21A6A13E6C68571BAEB3C2E984A6B98D09A0A78280FF518682BE0180D2A601F6A28E01065D20445E8876EB67E48786FEBE7B1F5B453EFAAAD8AD232A09596AC6F383BAD82DA6CCDC9769AD71D2E65AD94210FB97C72903E8228E193FCAAB6808EDD8CA7B9EF61F3F4B0A90B5922A4A6C14EEB10082CFD60577B11A347E2883F31F13D10BD80485E8871BDD7F5A7B9C11674B9CBE3B64391EE2DB95356A4DA11DD7B416AFA281E7EEE82AFAB20939C206EBE649440571F8EA1DB59385A38737BD5ACF04D32BAAD88754C6F5310EA3EBBFFB5AC319B25F60396DDD8AF65CC6137ECFBD957CE1BDAD30ED712B6B8B1F3B84E4B31614D82E6F19B2D87E72E602B6E5CF870DFFE5325DCFB62505EF72ED1122E51C5B6EC26CF4CA402332D654F708FD49B8F7466A1A04403B331DEA886CC9128877E9FCAB296AC9BAA2BAC6696A89ABB668BEFBA6244DF649CB8286EDA7E0CD12883146A8B08098CCD31C4A3B4C51839C499195FD63325F9FDF918D251862B3EBE16EC76FA9186ECB04BD268F22999BBBC982864B07B53470AD9230C224DE83401B75465C9731B67FD5002CD983B55C7B8EB1AC4AE11AAA11BC119CE884054434814DB79106FDE3EA3E322F811FAE44A0BD4CAA8C79838A5EA34EB3538DC4F9ED08180D7382B236966E13D16B47783E92C318EE26FA298B7936975652E6AB3789B7295B26588CD805DA70569D5D49AE73C361F9B83E56FCB2E496FF3CF267A1AFE67D0F5B3AE6DE173935DBB8367259530FD7CA41AC19D9A63D03D42CC31B60D5842201C20E00022398FDD44BE34709D4E0B3530A44D3DBD49BCFC13F83CA73E97A29E0075AC9E71409FE080582A606437A45F58EC3BA2E325C536D93A437C7728CB6BDE27A65DDAACD7F7121A2FE1268D23CBAAE29379C6D4FA5E4492D67947A68B0633106F9B6FD0B9987CEDA61C3626381E26044BD6E365E82763C19420CD80AAE1935CF1A18C6EFDB44BB64E3F7DEBD13FDFAED02F5FEFA2D4D81B6C7DD12BD7DF385AEBBF16CFF84354967FE445F29F517917DEE55333BBCB33F6FEB0BB6626F7D26AEDFCECED4A5701F6059FC715D19E6DB769B2C2FE4DC96E0F5992AF578061DBECD11A4789FACC1FCF7F6D2FDC4E5963835ED6BC7CC58E8D17953D59302F19776EF900725945BBFD927D3C580D3EFE91BFE19E795EBCCEEA5493E5FD9CC79FF243F53A4BEA8596DFAA585F77210A08529C1771CCCAF20D6F7396BCCC0F5925A087727908F5655E6EA314A1D6EBFD913E8AEEC9B4219A83A504BBBA57A6B9BE837B85954A75BF424DF407F9623CA078C2541E2DA21067AEED53E255177C9354BB0D432DE1CFF96D9A9921D747D1D5D786A09AEB82C352C9F7C285587AC1C6E50FAC6C630CD7E2D572CC0AEB62E8C56A02D022B5A1931604FA75ECDA3D6D3ABC69CAF16E7877EB45B97FCFAA077DEA07ADDC370597C97DCD4F0F34B13F6CC889C729CB63EA94E5C9A3EB9B277F79FA53943CF9E947C6E7B28B4F5F30431E6E27A156E51AD3A5A6F9EA4C27F95714C7A2C9E9F7687B089D95C39B4D82F1777DB169487ABF4CE63E6D63BB7DC14AD3BE5318368C38BD31E571FF0A92DB53584B738BF0E66399B247E9EB94A7B7699CB02AE289C659B3F7AB06391FA1B32AFAC760BBA66FCD7A2EAEFAEC58E90FFC18B6B5822EB4D2DD6D74C11570C927FB428D271ADE176AC41EBF2FD414F3437D5732A917F2081755FAC85C3C297EEFCDB88E544AC9961EACA46A2E9DF9321EA013CD41379F72A7396812DE3B4A6B3A4AAEA754CC9ED33C992E4F5E66F4DDAC3B3473F86EA132A53D4F6360A598F01E1FC44E617EB92FCCA556D75331783967F582884B539807A42F5E4DF67FEA0CC2BB3FB5D4E3F77E60DF048C5A57C8C78D596B31A72FEF91B810BEF751D6BD8872EC678E775111AF718277C7D36ED7781579C7D556703CCCBF7CF429DDE63B56152365EDD4773A79E25B663A1A36DF53D2F541F27D5E2469146ECD02CBA4BE7B345B2EF52BAC5119FD831513A984FD2FB0AAF566C5AE7E729D7D3EB0C27C28E3F13CD789D37D0EDCD69AF86481DF6DDCFE0FF30DDC2196FDD6ED183528058AE36D1CD557C4EFEB504B27361A5842A95541B5C231349522D126B98F72E9DD067431ED290EEA7E573257675B132014126D6ACFB080D20B6DED5B947E5C4062DAB5D0D69460761620219FA9FBD4C74703747B48276F02D532AE1A36B26AB2ACE8C0B57D151D8A1ADFE3D3E7647173D00FB9BD014BA01B529F8BA5D6A14D07167B00A9565439442B9E123C69F4EACBE763494E71C49AFFC0CA960F5A073EB959626EE3F564321977EA7886C0D20B77C24339390FE3DA6E1E2D767EA6091673024FC9D5C5F41ADB961D6C8662CE92D90C2FA9D1DFD1A6587DE9C16D72E76B800CF5BC5A993C9BE14546A9F3A981BADDD7624C33FD1EFD6DBDCE75ECAB8F6B5DC33914A64B5D8F429D8032F55401CED341AF0D3A68B7F0DCBDAF57E6B8CC7D7D74C6E3A90229F97D5780F2E28A4AC6F360BE8C1F7751594DE790DA7FD9B72FB6CDB7D6FB659FA5D9ACF2BB77DE66CB22CECB8ACDACA6268F5915D5E430B7AA3256E5336BAACE625645D519CCADA7D0CFD1F93B84ADC9B6B9845D2C12F370177592F3759357B97406C47524D204DC8F45505E16F768A64DC6D59E67130111F2314819A9E0F16B31E71A9CCAE96B2D18A00BD2E30439D813FE50CF691CE83915668AFADFF9F9215070D78792E0A98BD8DC575DB411D37AA8367901A2B8CC5E5E94651EA74DA9C00EAEED4BCB357E9D251BA86B691BCB43B1DB26D0FA336F0E0ED774CF01CA4BC971A029979CD5D0E9C7ACF4DD7539B7870F1EE8197294B3A2566E54F30994BC0FA559A57789FAD1A37DB4755283228538ECD5AD38E4A786BC627B96D558705212A520D2D10DBD4443C68A19B0A9EFE25CC09E05927C5CBECD8B747490069F8995C3473EED4711431400C2544D4B028F47DE006E219754CEFC5F02C1D651414B00D8516F9422D5DBE5E286DBDA781EF7167C016D936044B4F0ECB61FA4ADB91F05A6A93A5A12D454CD51513DCA5B0DD5BCD4559AE5AE50362783F0DBA57071192C99AC09535AFD17C0264D479482F492568322CF3F4A843E512F3165497DA36334791854086921502AC95CC049C911402854A97920EAA0920570EAA02E4A695471AB81760F3E4F8C81068C0D017388A84352ADE52FD92BB66515DBBC88AB667DF66554C651A24F74F96432712B18805F81906916D41A35B4004E8D8AA0E43F0A580F93CAABC068A3634F040B386CDE93A65B45F4B16B02B4432108AED512D8812B4F424DFFA8FA3A80815F36441BD9F2F2A9D0D6F2032B0E38B2BCA48864D19F7F9E0758C66A2F812FA3524830C31F5B5D0267E83BC0180CAC6FFD52462613CEECAF0E13C11C0863B60A2F80329B4A2845909961D759AE5149D5D1751194615DF0DA7B824E87F56EF4AD8E51ECF0C2D03C4B2948C5280D889382B8AD9C204AA014417C00671504298CB1584363F4B163330F940774F420A4B3825080A9721614C1D5A33420C81940C70EAC024AC62861C192A8E94D86AD853582DF20B8D15E65B0DAB270BB6948CD16848C52FBE9066F89F10AE2A943071723699DB85B2BD0C9B9ED16181F725A6C0833D473C961CCA00CD250A6BC68B6AE61123061352310BD771803053119FA03779AA1D26BB9A4B1D2357112064B6137B735B84A751E04450A413AE21E75E495B3BA4772F516848FAC82A3778F70E234D3D2B485454D5E5CEC98C31C169BACEC6BD403500117C18D555E70ECB32A87BA283E3E28BA32F0ECEB9B0622BC60505BCFA9C2ABB70AACBCD631D7C793CE55681BACF61A2D61984170AF132212501ADE8DD2EAB7E028A8E9E0A45CA8F6BD135B3B2B8F9F04C18EFC640AE23FB5E7E467759FA4BA2D881BA9FE47EF3CD9DF08C6DADBE1C160EB3064C215FD99613D1FFBE1AD70368BAC0F0A26260E85649D51CAD20B5BCDA6614F3E131163BA7B301D8FA6EB06DA1BD50B616F856B0616AD9C04CE7476420C0306AAC2B1F5B16637810B6738A4C32AD0388AD6710134A16AA0E42D9172AE022484D60F6B741BC7DFD8F23201241D5636CE4A3B680381CA5CD5059065D604A5001AEFEB4A63627B8422615FF2EDA1B9DB35FE69F0FC2DE9E031524DE2365C9A335CCDBE1135B1C8D84952116915433ACF754CE8EC3F39417348B4082EC7DC8E09949A0ED641A4A61C321C052147704C70A807C95C5AD2CD706810CE0704A40DFEC10F101A75B0002C895AA294E4088E138AB5B1CC37F4A84EC8B31CCC00A44F59529901768B4F4070959C1CB88677CCEDCDAFBD581ECEACE9EFA55B179B83E348ADDEA2385215702238822ED5D9CF921912C117D1AD3718CDD7D00DD91D8125A3A88302079CF4178C7EC3E2BB68E22D75BB62972CF8123786F5A5F2A63838D8D114E0ED602BE68C1784D1ACD6BD166CD3C0348CB85C09B629686A491640A0C2998E610123501F01D0F3EDD3F1853D06A0CA9CF54E1C5CB105C66AB8F6B48CF1B74656325A36F810DE9D98D36CAD0B317BE5D7B4581E005CDB6469BCDBA885C149B80504346CF10E660BA7B30720ACBE02318F11C3EAB9841DC3D441CA1B7E2B624543D63CB2E0625AA48714663562F2DB0E6B61CDA683556D99A8A213B0640652670760A8B4CD7382506393160F6A2A0F102C053FA5FE6B025051CF8942B0B9353F2C7A3B41514EBA0C24953C57A5D8A0EB645598C22A3B01B8CAFCB20EE7476D0967A40AA69D215DF2F02855190BB88F54559D1C365BA6781A42644AF8F0085468E947F9C0630D335D8346ABBB38C624655072D7DF1E58055E1A99B6DBD9025A720884361A73130E89B9AE79E0C04D3114C058A8CBC9B875535E8092AD8162FB8155C273F173A175CDC3ABF66AAF8A45AFD3ACEBE30F78F9024383E9190CFD9E1974C7CC8435C30B1ACBDF62C3AB4A69D58957D9704D5032AF532D749FED75534C9EA6E22958D115A0FECDBED6CFA6690FF1F0CA746FF194DD632E2A1A6A8197AC428CE3D9E6F5F07C0A6ADE3484C93215F74E13A8845BA441B3144D2414C9564AFDB90BBDA47A1CAA54614F1A172B44B2C81DA8E035614388B564C0763950342096AD85544670BD79D418168986032C9A6C435C4B2EC2892F4DAA1066912270F36A5284309B9486345817D07CB6A595493675217238455ABF626596D5C7B2B6A6EE5703CDA847A2A1C460BAB4183489B8247B2FEB99E2F49ED5875824746F6369E987438496F41AC921240C6042B41A75815D0A30E942A843013B222473013B2E22423FEC581BC07ED8853914AEA5183097ADF5902C420D08254353BE19A7C991832DB2E413089A2C3998240B95421FDED5AD447C8C5763DA4A088B23A5D57698006829312C1281F52F4D2610C722D5065510A682CF89386FFAAB781B2111F85CA5F91D3DC38A21FA92DE5057CDB3D41C70B2EC7EDE23C8B6BAB9E7B2BE28BAA43EE70669D5EB29385907AE8FC1899AB679BE7E39017A27386E13346F7D78CCA47AB757CB608D90DF2D83948F7ACC9E792DA57ECB0B5980CE5DDED4922A4F7C554BA83132617291BA941E29CF3B01CA747E154ADEF07678174A5480798EE79C05A063CAE4D45DC9F07344805A09EF1649B534BF5C24D40B9D2612C4016AC2E7AE1ECA51DEC581D4627A3A47AE01F2788EA80A60C26B9401D41F9F757BD41F7EE6055203E14118B926E62761C40A9926F014999092C469FE6435A1AF94008AA2BD682255CBFAA60905FD348998AAD0F5130FE7447D6603F2418C4F71C8C33FF618876839E1C507B31C4015D83288BB12949722001598DE92900A8EBC262114BB5B5331541E793C429001ADAB04D3C2D03EB81AC0C711C03AA8CF237829427D0DC10E269F9E0011F883534C1BD1BF32F93350FD4BD34974D5CA2E6F91DE2195D0800D8C9F1E6E5A80A1DE0F2300213D4DBD1354D22F19E2DA80D8D5C1F22BFCEA5E3A50E8D41183D1173A88B30A7381230E2B81385CF332CDD4E18AA705AEAB124582A031AD7B4D5198D179B3305D23F5313A6D8EBA59D6B008A5C33B12C2D30CF6039DA9D9AB3BE9C4CC14954E5044B7728A2BA18D602F79136F5AE55B111653D21578B202ECC4B880521CD974A55AD2F974EDC877148C77A959966D303E57BB4209ABE636F2D769CA33AD90DB7653DD15A51392022AB2B0964AB5C1794B857A6015B0485A442308B326A0160A07A754230B0BA7502DD366224524A0A9802AB2314382BDCC814C52E91E343A490914B6930C4E392C023B239F214DA108FFA1ADAE3A03625055EA9487B3EAD146C3675C0E239CAE47D6B0CC07EB272C8E99CFCE3BB5D4446DE2E3838D660EAD1A3E42B8ABC93A46CCE2680024684605C1546948A534B2B4090AD2D8D16CFEB1D79EAF81C90BDCE6A5327F29BBAD04EE2FB74D2BBAFC85F185934541BB8E3466297923D0CA2DE5B4C54A94BDD8D6A242750428CD448624D506A14312AA001FB8320901F4603CFB150440066550697E6CCD6C50D2740C2DA73C9D75060290999A466E7E949C46AC04702ECE22C5741CC272582F0CA41A0A1522A074BA156B8B4B842B61C12431ACACA5BF9E0184A641902FC45651953124A816558A1069C9D07C3C338CFE14FA0AA21E4DA417D62A23B41761F58AF05CCC768CC0CAB5603D7EEAB42249666808700495B62A39CF61488025C0AA48804CC0503B994E2080BA64FE0041A0FD6CB4BB8288F7DC019DF9DC90976AED7847DEE1BCB24F364B4DEC0D57B2294AA6AC7612AE700753E6522B9FC04D62405DB6FBC6525D0C378E853A807B4E363981F7B12ECE5B41C365D821ECE2FC32BE63BBA8FB7071CEA3C46C5F1DA2EDBB3C61DBB20F7817EDF769765B8E29BB2F9BCB7D14F35ABCFCD7CBB3CDD7DD362B9F9FDD55D5FED9F979D9882E1FECD2B8C8CBFCA6E27672771E25F9F9E3870FFFEDFCD1A3F35D2BE33C96F4AC5EDD1D72AAB82372CB94D0FA4E6FC2DEA44559BD8AAAE83A2A7903BC4C7640B4EEEAAFACB641C77D36C8ED5EBD01FB0B237DC2FAEFEE9671B48F7861F252BF01AC881915F986D76DC7DBB8A9263375304D041772C967E151D15FB8862EF0BFE4366897116EF6E3F2F2EB66BDA4B7E9A2442548977971AED453D5E7B9A65005DE6A43919A511EEFFCDAD02883D08096F498B6D546736BAB2CDF5D174C96D07F7368710EB82A2AFE60D74A730BDFE9D2B857C6725950F7892EA38A922F69599F6310C58C5FE992B651250B693E38A4CF6E95F4F50787F4F9ADA28CF60B5D82FC2EB928C9FC62F96ABD9134C5A07449BB2042BFA408C1543FB297896A373D6680494A06675C9494A07E3F2E699766FC67C9EBA3186729C0415EF41591270638D49495F1813784827AE1335DD6E703BB8B0AB560E3572749ACE41FA24293357C7731BB69166F0FDF34CB3B7CA6CB8AB8BFC22719A95230E1335D162B85C57909B262005D5EC9EAC5B5E83ADDA6FF15656976D3944A168DC571307069FCE9B0AF3D8B345634AA0439A1B0B99FA6F65DF1BBC37094EE85CD2655A61EEA26595C3AD725CBA14763E4F5FBAF9E6E974D0EC5F5B2CB3806F76BED9632DD6D746A2A54904B5B1984FC891BABBF7BEBD742486A42B3A029FFC46D41BB154CEB395649A4AE439032BF2BDB3DCE258A41DEEB329446B9DFAC950B083F1A5CA817B93D2737662994998D4DC29FB8EFBA9CBFA7B416591EA1DD1C64616DD01F4A575B52FCEED0A2875D941CB6CDB697D4AAC27727697C1A00C8EABE3A4982E71C5280C3A4202D580CCCC2C7CFAEBDE02EAFD816EA0A5DC032ABAEF8DA93F87AA8BC06657A57149718C4F63B8F442BD990F10CA79FCD40D3136C8421ED3158754C4ABC9725D4BFDD563A5B020F68A5730C391A848C441A7E0841D3131062487BCC0869E849B4E6ED3F1E4FCBD6342B9E8D0A24A5B42798EC189A72AD269058453CDBC22483D228E6F4C7D03AC7BAF115D2D9AA370F8A740F48130396708CD6EC0BDD29C2003D0196E4DA1F3029A8E96F2AA1D9FEE1EB9C2E24DED7AA48ED6915E8CEAE3691D58E97F9CE606D82485357BB90798CE2F764CEF8D490DDE499B2433A7E5D7386E77B9A68DD759E89E7B72C52E86B3AEEA7B7C2AEE43493F12B5EC082DD42F3F431C869152649D53DF8E1A3939CBB5CDBCC1FBF3A9C30EACF95AA4A93021CE624D2A8060E5052A8A364E1B635285B093FB6BE35AD4FF9F7A5A54696A663544594951160E0F55097F58CFA6E8DBA92D17E73281FF76A0E85DA9BFB8F0E6B331D619DAA2DF1FB12A7D2D0F20964695A19953017A9497A9B7F2E5479FDD7A3E96D387D216987114E4DD955C452621AEDC998D43612BFBBADF13787DE6FD21838210704D365D77B04495AA78A94457A39E46830805D46A020A07FFEC41D01684A4CAF6F27D9DBD7BB28559AA3FD421751EBA9FE4B05202BB2E62B5DD287A82CFFC88BE43FA3F24E3511DC558A4A963919D90F7779C6DE1F76D74C3DBBECE1DD075A712DD21D2BA23DDBF2F980361AC9612E47036F0F5992C362B5408F79D62364A2A53DE04792F61891F678DDD956D3175ED637078A1DD3C6BCE673BBEFE7DA432E597C28EA0E5E45BBBDDA386D50D90679619B50641FC07FFC237FC31D9BBC789D45D75B557AF5477ED384B23E942EF9E73CFE941FAAD759C2AD25FBAD8AB5F6AB835996243CF850077BC806CA3C08762EF18B386665F986B73B4B5EE67C9EA0EFCDD731F2F2266A3AD931DDC701A8A0FD0635FD192EF7E18D20639E81AECE5095E0E72435C5AEF5A31F0F7616F37BB43D2872BE445BF852CD6AD7B94C6CCDB4CB5CA8048A4B6C4ABD905BDC0CF36CC7A78BA5B6402D05394C85D21BC55CD71F4E6709768E23325C052C0367D87288C3A4E3368D135671A31CA96E9112E4E0C2E545CC811AFD43BD1E217C3F9ADE0BD07A4F37FEED1387D38C3F22031FD679F40FF5298B4475E6F73875352EAF17F577F64D96F6A9FE30E7B0B2E2E9188C1D9B7A3A064C4FD9A8C4D3FE790DF82C670C171A148EC0986144E7AEB6AC796B729A298345CCEF88F62FBB4B3B5535A3C551199E89BB8113B601DDF7FFA6ED5DECA22256AC4BF7C941464D01A2782AFD3797925469C1ABAE9566F84C97F529DDE63B5615EA1972F1BB8343B68B6E99B2ACDC7F73DDCBE10E579246AA3320867848ACF73F11916D90DB65EEA8E4FEA0A63B3964FEF30068AD59B1AB391CD8E7032BF4F5482DD4ED2A2DBA33AC051E8DB192B8E4FD0C964904C1689993CF63B84EE204AA4457EAD734261184A63127C79BA663B1555B68F8BCC651BBDB836A39DB2F6E12AE9A139FEAA13D39C4C1BA1DB84EAEA24351835FE586D0028F0C989320E90DC6C50EFCB1ECF6C047696576307C3D9AC6C09868FD5A87288DD05C6449F377FD8611598343FFF1685A7242B379B6915B831CC3B58243A1ECDD371F8EA609553A63DF9527A314D2FA9345C23C6D9CD49C41DA1589C4A985EFA2521D5EBB4F0E5EFE977D7B735871EFC7CF4EB2B2543D2C3D7C7492D35D1AD6440DDF5DCE95951583EA280538CAD3EB297C769405D6550E71B01DACCAA1CA8ADFDDA4E9551DBFBA49022B2A057C8777937596673F4B679543B0750419F3583BEA5834EF8828F372EB2757D5D0A3C15088F5EC896BD96EEBD8D38E63D4FF1EC5828346D4AC461972EFBE0CBF07A2E68E2459626F6EEA5D733137F52D3BC2669535B98D72B6E977239F9FBDFB76F979FBA00E7FD0FCF9B239103CC6781765E90D2BAB8FF927963D3F7BFAE07F9D6D5E6CD3A86CE9B43B3EE867F1A1ACF8F430ABEFCFB564DB0482E8474F6A826896ECCED5E4EE34D3B594B24CB600C974DD4CCA7A26BCE075F177F64D6DEA1E46BFB21B684DF45C697855C285BAE42026AE0BC6CD565AEB5BD5C0B3B759C2BE3E3FFB3F4DC2679BB7FFFB4A48FBC3E6978237CEB3CDC3CDFF3DDBBC3F6CB7F509B3FA62C0B6D45F9E376F04B6A5A869B345495571500489A8372AD9301AD034ECA358559F8DCDF91B9FF61651C5920F5155B1221B4D8FB3D27A6BD1E6F1252AE2BB7A51086FB6B7E56F59FAF9C09BEE235765DD4CEFA2AF3FB3ECB6BA7B7EF6E8E143F76613F898DB525CE7F9D6594CC7C6ACD4032F9B0E045DE648CD1C546CB3998C4B7CEAAEC3667B39ACC486CF995C6D924CF90E4D2B3B23406EB014A200D95488257BFC174BC9C83DDE466645EBF698A36DEFFC634A4793DA279C644F471EE736F772579FC9CD2A67411287F35459227FF34459027B732B296171BAABEFCE7CA8173ACA66BC7FC4D1547B5E3CF8B16B471F399DE1C188544A91CC79821881C679821481C079821489B87982CDC7589A278854B89927481249991DBBEF98745207D6299CBB7270E1DFA86551856025228DA71AF3B367814421F402D13D3D33F5F222DEDEA09253F7F8DCB58E907FDEAB7D16B58324C9F7139A19E06D213A9EE64D8291411ACB63F73BBB42772E19474595D66B5C824FE63EF580A8973DC61E5D8C434DE9D30E1305F2BD151C7BE78F4F43A99CC85E4C533ECE72636F0431AD63E71B934EEA7E223FB20A0777511D3DF27441AA77EF2D4B20B7C297371E3F7DEAEADC4A14C9B8E41F9D057BAE6B426B3AE27D6E47748989A7CC0110EBEE30B85C352286323CAACB306D70983ADC29250A3814208CC9F7EE197100D00B509337B799FB188FBD44D9EC081731F11C60D9C3E4C9DF0B58284BC5A1D1327038BB36759B6E9656D62895BF97063E1E77D0C0907CAF6CD043A26D2A9DC0C6978F7B48DE6D18589D8FD8890BD66FA00B1EB4DE83B32707DD5E1BB371B5EE5DC249F3AC7517595A42E8E067246C54CAA76B3DFFD4B66BA4BDA24E6C89870C96B765C09EE6E267975C97A5A61CEB3AEDC52885DF39E89AF0C0F63C7D71AA237B9E2848BACAEBA86F21ED2485EBBCD03E63A320607A691426699FF2482266ECA8DFCB60A7F34307ED793D5DB4FBA91B5AE97B7EABB0C7D7444A698FC36B63F20947D7E015A963385407E84BA1B7F6D19924825A3ACA346AE4CA6E8BB5CDB9A880678521FE699A3DC0396CEC76414CEBA1EE317950200074D778CF7CE2DE3165DEEBE0731A90497A09DB9E8196CBA3015A9EDD30EB3E3FB9B7CF4861BD5A1144DE6BFFB517CA34C803BFC8C2DCC4956B85043BA8708D0A3BA87491153BF01A9CC0901D74F3F73866B200B9F6B4D3B522A5B67FB78109B427944CE7CC9E200C60C9A63ABB4464485CD9134A0AB16353B732C9A39D85587A89716F9629CD71BA462DD9755053D4F15E4F90E970230EA194FED37ABA32096AC853400D2BAA41E077790B2DD8D12799F77A820D56D8AE27481269AE832C84789978803E9AB84787B34503B14136E8C026412851E0F95353FAC0328FC180399D2C0288A7EFCDBC9399A7F9F0809D5FEEBC53B8B3A6E6D1C5630A6F195DAC12BDCCA34EE53115F3F0261DCC367DAAFD63A88E4791BAB44B58B529DBAAC7B86BD3916487DDF5E849B3034B1D19B4433AC92297B6BB4F45C9A1E7D80EAB0E996D7BA66D31857F7BA65C644AEE893BE2C7402BB3D7D8BBDB82E8F36AAFD93FB4E9EF7A1DDA6FF39F6C27712AED652FA32DBFAC4E56114E694D5511CA621DF4C8A3904FA7DD913D8300B621F9099F7C6CF9B9274CDC655AEE0982342A6EB22C475CAED0694758053F8839906587992505BCE24D22A79EE19A37423A7DEC17BD87623B66DEA59B63A8F36DAE639C0EAC7ED5AE212E3538CAD6056187F5290331F5E9B660C7723D6E473A4BE838AE274810D8ADE79A97F4ACD7F3C91F489367CA42A2C79E338F591525F368CF948948AE3D6316B32A4AE2E19E298F258766B29DB590629FAEA5B50D551E6B3AB39CEAD289B71DD1A10A980325380FF6499D9A74BF7DDE6AB9AE76FD57F3F98789471931A5BF28CB3C4E9BFC41685818A15F6749534E95D5B8AB6C4D81FD400979C76D76BADFA6312F0D57A8A6BD51A496B728550F94053F7CF04097CDB1C18A1A54D1F6659E955511A53A7BF987A2263FD8475BB0664A6C22F0EA0618E4AA21AFD89E6535D6B17A53F234BE3878713EE4A1F4079B462ECE05845880A3B21D5E0DF358560E1F55527D11421A5DA204233D94D0E2A374809349140F05CBF2FF25109CCCA490F340CA464885E4AA136DAE8BAC7161C4175A1A61AC8C2D21F8B4C185B0BE1D1DBA642ABD55D0D5B3E43A42AAE7BB14DB79F8461FE48E0539207DE751C14524425E05282A6BA39D89536866858B516A63358C8E1EA808B26103C267C18F916C721E1C59F58F640B9178AE02A8FD40E4355CDD30189C21B6D4C2C25715366A957EC95EB12DABD8E645DCBE41F3322AE3487FFFAE9E2B245829462639B114C2D759D0B58729C9E6C11542968764B697A8DCD6C151CD123694C380A09AF24B024FF3816E6E1C2118AAF135A6B279DADD0D6403A5DB3A4D2ED12374B40186969788C8A4C693431CB0007034A182FBF079F081B3ACCD04141B3D1506199C8F6A09CC8CF7039B829408319DB7AD27A3850EC0400871B3E821D141CA50BEF5B9CE14BB6395B05A929E9140F232FB6F743CF44427A298E1DB3C5363884A016910E3B16B3A12403617244B9115641504F4756E2E6BE2EDDFB318880D377CA3B7BF7E3D54140884CE820990920169A08958B0DC8745323503714154C04424C161E1605DC22DF02F888270466889314160CDB18F0BC21D5E79F747F8EEB4A6BAC21081DD43F66AA1798609850C695DA380DEDB0E6F1802C1EBE80D4450082E8885E602F0A26E437BE518731BBAD0EFC96D00EE581F2B2A868BBEF24111CBEAA674EB7A585AEABEBAD80AAFA30801972A813BCE5E2DE560365CCF28EC25BEBF9541625FBF0A878EE5DD8A5510E1E2541C0116FA5A630C01C1471247449DA4331112780B62A02EFCA29E4473C0107324DAC0EFC98FD0CF531E2B227AF66FEAB37A5E569E3058580E691862CD65455CCC7B9891C4F3D406CE1BBF0E86AC0759C322073CBBAA857D3F28713AB3BA3A36860BEF5607146C47AC0167C245A051C7A989564085C464B00A2C242E84FE0F1C1B12AF81D89E72001D234E600B840A9C9C611E6438E5A5115CAC3492A88F125D8D7F1A3C56E03123B9D7EBC1A7644F6C6F35CD831F1FCBA23F4A722C38EA3FDD83E83440A4BC25B3F2719E013D247314F054CF64509EE2F91E4FA81EC1211F1131167FD71124B4ADDC50D3E8D344CD9459F45181A75B165AC4C238ACF69D222A5C56008F0003C08D0BC2C990E977544ECFB678DF4D41F99AC0E8CD036B2BDAA550C55DE2F69656C3ABA6383870275FCD3B919B5BA19B7E892B5C86CC17C0D2C05F58FF0F0750C79A27366BFF890E148912521735EBCD0A88F60F69918940C0892FD1FC70A6CB95CC890D0EB3DA933561B2A6057106CEDAA6A3261DE40A1BEE9AE3D6A3E610945AB2F9E071B55CA1910441A7C699C79E68B488482385BA616E22D0C4B286493057342BBC402B1995E343D09AA6660AAA56B63A00AC5AAECB9580A5126DCA67B094B0EF0E48469AD1D301507389F4CA7A8B745E201DCD2DE45501E57921796550C954730EA7BB66209B9B8CD213269C9B01BA8BA3A7A61435DD4E0B0E189DC354140B84CE74656D61AC58A85B914C75BED15520A3322B3AEE9C4E22A43C857DD4399827E7DE575D9FF8524395FDC8D86C485AE3E8D8AAA83931925491D3F8AA3E8C8F6344A23F866E274037138EFDCA03CEE98C34D91AF71E8A1C7C46711688BC6E8AC7D3543C052BBA12BCCC13F6262DCAEA555445D751A9132FD4A92E598598A0B3CDEB81EE19B52A97F11DDB45CFCF92EBDA5CB4D4D17A2C0D4E72CE8A93A365AB8443792A512C19429EB8962B1409CA1A8A67ABB0CE43AC575A8F03565C8F46CD5CD814C473172219B317E259F21F084EB54C871028A721D05A3D60D313A81F100BAE2010D1062F958C53C7961A0304961AC992ADE17C825600435CA82886E89642092776B442086150A642B02513813D50CB4408833211826D99344487BAFCE63328BA09B14995A9CB74F17238988F1CC525C37E35CB9C6D1FCB9A791FD10A547D2E0220548F0443538F47EB2886814E8B61E814E4616EB801866567CCC66EF87A8E23DDD8F521A081EB032DE28713739AF82104123F045AC403745D5A46401CB8464D90D5E910585F00974308851D0E218243DD3A4E1163DDBA38B04D6C8208F6B0BB820EDAC32E0CB3875DB043AD5A6FDF58A9368A0122F573DBD64C0D7DD6DC59C9BD54BE70A5E522074339C9312CB9C9272BB4DCE460283739062937341F530E749F5ADDC3C51D6B35A6D1BB5623DBAA0AE78D674492AAED2B02DD4B890177322592255B602558CB188803650D4423F6734B1FC7FB37D4AF85992C320FD49F0DDA0889A099A1E5A121D362FE5067CB4CD2B2002788B14E82CF651550D4437D1C075294D7C33AB2CAB0496BAB36DB3CD4BA53260823CC3326A8CFFA028C497F6ECFC7C00AD46686B206D119DFEA2AB43C7302E8CDE56114A97ACA2A41532764096075B5501EF50074E3FC16885C517891A1ADA579E5404125BA5ED2C1D2BE00E2AE32F8D90A404984F72DE4C31CEA5240530974962FA5D5D62A9AB4F8328447B5955716A00A9B1E6290AB2A2C48B4B504161CA628C7A782F09B02503D09AF0FC88587564ADA0A9816407019B2D7AD4B429C6A77A5A0A4F9805A6804FB53601B42A93EC3AFCA0E0F8DB2460679D96CC9AB1DADA9829732946D726911A64987ADB0B85752214007AA68A248970AAAACB73405451653D01D3A6921A591008406ABF4A07EBCD6087775806A3BE0C107BC108D35381FB1D15D2BB3106D0DAA9B83A08B4B2B80592A8DA16D71DAE110EDEBAEAA0955EE98880DB585B88A83F75F69B150EBBF3F836B817EBE184CB48BF86304565ECDED90962307B7035C690C31519FA406A3DB62219C0D56F165FAB650161CEB28076800B83BAA684255EBFC8C5DBA8D306F8F1617D1B40EDD064EAEB09DF1125082234DA62F54A17496293B7DEF79B2AA4C4B8D240EC8906A0197156D7B8EEE2AD0F90B81CA5B480EA5E283E5C60ABC62C511863EA0F6142E3FA922D01E52530BD3DE90BF12BD806FE6A1033B8003759DD2AED87E7FD7B4B61DFC155162245AA369092166FB6E5464231133AE72104ECF075BEC98ACE489CAC1EDAB8D552BA00AD61E72010E28A34260A6A8600A7170EABCF69C0C6447E03613951C29F41AFE91A10467DA81365268B43C61F7898E601345A1900134632299912A209F0C69CA0C9FFB005201EBE8C6532941D060A834955665463C2CA5189D09040281992E442EB8706CA62D30702C06561C7CEE47D69EE5104F1864345C17445CE8BC1833A2E2E854D5F337D09405B23DCCA82EE4B055B740643E4115463D0A3B01514D264E8339D5B5CADEA6F5FEBDF5D496D3525388735BAB1C3E022E9A5B3503DC470FAE0CF4686123C77E5AD05D15C40BD480767CAE5E4B959D74626FF5A9A4E18E3045599485AB700A9A7B010BB8040B28C17655165CA747D7E8A1F5F94556FA2FCE5B39C315CF21ECE2BC3D71DB7DE03FB98D8F6ED9BB3C61DBB2F97A71FE2BB7FCE98EB5BF5EB132BD1D455C7099198BA52BA5439CB7D94DDE5F6D554AD447E983BB6679C72A3E1C57D18BA24A6FB801E5C1312BCB34BB3DDBFC1E6D0F3CCAEBDD354BDE66BF1CAAFDA1E25566BBEBED375119F50D5953FE17E75A992F7ED9D7BFCA1055F8BD5935A8D82FD95F39DC93A1DC6FA26DA9341A26A2BE7AFB37EEBA156D5B56457DB4F3DB20E93D375334419DFA861BC31FB9C3B3E5C2CA5FB2CBE80BF3291B87DFCFEC368ABF7DA88F7D25ACC085D81B4256FBC5AB34BA2DA25DD9C918D3F39F1CC3C9EEEBBFFF7FFFF851D6A5900200, 
'6.1.3-40302');