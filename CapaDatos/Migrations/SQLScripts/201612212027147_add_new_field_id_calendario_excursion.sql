﻿use portalexcursiones;

alter table `reservaexcursionactividad` drop foreign key `FK_reservaexcursionactividad_calendarioexcursion_exact_id_fecha`;calendarioexcursion
alter table `reservaexcursionactividad` drop index `IX_exact_id_fecha`;
set @columnType := (select case lower(IS_NULLABLE) when 'no' then CONCAT(column_type, ' not null ')  when 'yes' then column_type end from information_schema.columns where table_name = 'reservaexcursionactividad' and column_name = 'exact_id');
set @sqlstmt := (select concat('alter table `reservaexcursionactividad` change `exact_id` `calendario_id` ' , @columnType));
prepare stmt from @sqlstmt;
execute stmt;
deallocate prepare stmt;
alter table `calendarioexcursion` drop primary key; 
alter table `calendarioexcursion` add column `id` int unsigned auto_increment not null   unique ;
alter table `calendarioexcursion` add primary key  `PK_calendarioexcursion` ( `id`) ;
CREATE index  `IX_calendario_id` on `reservaexcursionactividad` (`calendario_id` DESC) using HASH;
alter table `reservaexcursionactividad` add constraint `FK_3b04473e2e73415fb08daf6d6d71e377`  foreign key (`calendario_id`) references `calendarioexcursion` ( `id`) ;
alter table `reservaexcursionactividad` drop column `fecha`;
INSERT INTO `__MigrationHistory`(
`MigrationId`, 
`ContextKey`, 
`Model`, 
`ProductVersion`) VALUES (
'201612212027147_add_new_field_id_calendario_excursion', 
'CapaDatos.Migrations.Configuration', 
0x1F8B0800000000000400ED7DDB8E1C3992E5FB00F30F897C1CD464E852AAED11523350EBD22374492554AA0AFB2678863333BD15E11E72F75049B3D82FDB87F9A4F985A5DF7931238D74FA25548906AA5341D2481A8F1B8D46F2F07FFEDF7F5FFEC7D7FDEEEC0BCB8B244B9F9D3FBC78707EC6D26D1627E9EDB3F36379F3AF7F39FF8F7FFFE77FBA7C15EFBF9EFDDEE57B5CE5E325D3E2D9F95D591E9E6E36C5F68EEDA3E2629F6CF3ACC86ECA8B6DB6DF4471B679F4E0C1BF6D1E3EDC302EE29CCB3A3BBBFCF59896C99ED5FFE0FF7C91A55B76288FD1EE6D16B35DD1FECE53AE6AA967EFA23D2B0ED1963D3B7F111DA297519915E767CF7749C41B70C57637E767519A666554F2E63DFDAD6057659EA5B75707FE43B4FBF0EDC078BE9B6857B0B6D94F87ECD41E3C7854F5603314EC446D8F4599ED1D053E7CDCAA64A316F752EC79AF32AEB4575CB9E5B7AAD7B5E29E9D47BBCFC764C7F22FEC2ED91E77D9F9995AE9D317BBBC2A20E8F7A2121347312B2ED4F23F9CF5B97EE841C1B153FD8FA71D77E53167CF52762CF368F7C3D9FBE3F52ED9FE9D7DFB907D62E9B3F4B8DB89EDE52DE669D20FFCA7F779766079F9ED5776A3F4E263129F9F6D64011B55425F1E2ADCF4F44D5AFEF4E3F9D93BDE9CE87AC77A80085AB92AB39CFD8DA52C8F4A16BF8FCA92E57C7CDF6529D39AA054985D175C61D1968B614557258725FFB0CECFDE465F7F66E96D79F7ECFCA7274F1E3F393F7B9D7C6571F75BDB90DFD2847F8943C3940ADF455F92DBBA9D4AD5DB2CBD496E8F795DF9F9D9AF6C57E72AEE9243F3B55C48393EEAF0789D67FB5FB39D2A4BCBF9F14394DFB292772F2365BFCA8EF9D6A12739DB66B71C8445CCBE64BB63A74CA0475A5548D1A167B4127D93BB1E128B758AA1F6B41347EC9D90DDD0A33E97BD174356A8E5979BC1A6182D8D023D373323155EC6C6F898961016E54DCC6A55DAAC4A9AEDAF736630270F1F3CA01913AD911673C6C15146F91FECBAABFCAF194752943A4BFA92C42C0BD103733565147F498A2C9FBE26FEB51A2A7932CD78ECAA6AE6AE344EB8B16BBE6CB4EA474F6CB359991F3DFA9BDD06018D63B5873CFBC2589C897E0354FDA3BF04E9343A3DE853F494B3BA3A5B109D006A67D8D7EDB1B6E7D1B64CBE54C69FD01DA810D6213DAFA54B4001D74EDD64253279CB55B5F9B0A6D7C996D636795C1BD843196CE40074A92ED9654233697E209E137201C9EE050402371F4397B08CA3C1BEF20678AD648692732C63E2DE97EB6B7BF893B319DD2729FF67C1B55E8C14147D0D238863617BE43E573FA9BC64DB641FEDCECFDEF3392E69C321DCAA5F6DA34AE8239BC0CF477617E551A0A59E636F78E5ACE03F44267767BAEAD32C49B7BBE33793633A5DED515A32BEF84A96E93B2B7A9332D6332EF84A322DA3EB6497FC579426E94DDDB3B1520FC9F6D3F1500523922D1B2B8C7F3665926604F363F1CE9343D6EB4D90F6D76F25A9EC304F5BCAE241126E0A6FB33CB1F8206AAEC1556045FFA33C4B52CBE8C1136A41D7304A2F5880AAA9B3C3C838F4D65608EFAEB5A4737F1D0360237D4B7310CCE08C52FBD37E75604FBA2FD23E52E69C5A2F2CD95DFB70C3B67711EC20031AEA720FAD473369CE329ED3D5654EE2847B96E446F7D98DAD6E73519ADD65756E77C9F6F4563799CD6DAEF2905A5C67745F9A70970B593D0195F4D98D6D6E73515ADD65756EF731AD56625D0498DC7EB598B91F726E527F9422E342BAFA44E918D655059C6268B7712EBE8BC8AE3D2EA34C2173FB455AF4C3D5A11A8773C149F2047A2FE11EE9DF0FD2A7718A51AC93DD692FB0F71EA51BC2DB62A708EBEF696F2E04AE83AD1B54041397199E367AC7D238CA936C8491D644DCC319AA8B1A67364BA9575E7D8C9537E443B2F709B295516C0818F97F30B260D883572A074128B8F0F6ECDA5A9B52C675C14DDC651BB9F8D67A625DA6D3CFFED407A8B0595957D050409C88F17CC0DC6BC83CCA6E693073DCB4928B9FA2BD5ADEABFC3150FCDF106505ECC23CF6448B0938D8202F40B79FC5F8FD5854D032206F9BE3B5312B969D636B363DEEA398EB212BDC26435D4CCAFDB5D142B4FD2A1F39614E1811372D2B837197956C17C06A2C7D18583B2EC53F79657FAC45A3B9E0602946BB7E7514D25AFF68731AC415D0F7A6087E03B527FD6080ED1F860A6AB59EAAB515C8E2DAC27AA8E07341554A1F48865A08E7D04F04C1D93CBD42B0AD9D01364C4E43B3AD99B51ED84B8C3ADB24A0C46D0AED0B9EA25FB882B04C28C750B55F07A18F8F1F791D3D4DD26D4271285CCE00D632D133804D8D3DA4F4F37F5A06F0EC9F9ECBCB2415C6ADB5C1F0A99921FB29E7D15C6634A3EBA620FDCE8A68B82D97552C590DBD09733DC5B818779EC14CAD352CB74D0D3C16C76AB6B63570C80635B04B3534B0CF326AF9247C876EB6BE2F786FEBA7B1F55E97130E515204B4D292F50D67A755509BAD39D94EF3BEC3ADAC94D2D721B74F4ED26710257D945FD534D0F133E365EEBFB069BEB0B161361152E360A77D10082CFD6027AE779CF12716BE07A21710C96122D79B68F7D7FD66D072753F234F0E96DA29F1B26646F70E97F96F07A8F7A8ACD115D3CD2B5346DD901973BBCEF0D4F095C7220C0F6521ABB520EB15EF989659CF61B60A6599F526FCA8D9A311B1CC1C32448037F6CCFE37E29040F344DB2EF3DEBFAB644C6100EDC7063E3A9F1B1877AE997092003B0A1D3ACCED6D88CD41EFA057613BA94358C77DEB559570EF694275DD3B7C73387C25DBB19B2C35913C4C14A81FE1FCA93751E9245341891F26233F52ED99236712FD7E9B2552AE9BAA8F58CF2C59351FCE967F2A6F7974C8DFB40D1C62507A29D411110A1887A3CF47198B217388F34ABE04784AF1FBB349A463BF1FF9FC9AB3DBF1C77FD3E33E4EA2D12794EEB27CA490DEEE05391BD33B8641A4091F4DC00D6359F2D4C6593F724133E64EDD31EE2907B16B846EE8467082133010F51392C576DAC59BC2D1E8B8087E841E84D112B536EA39462EA95ACD7A4D0EF78B277422E03D4E8B485A5978CF05CD5D6D3A6B8FEB7D9568CBC7C91472998A6A6EBB4BB84AD93C4473C09EDA8C34775AA49CE7E67373B0FA6DD5C5C96DF6D94417C4FF0C1A546BC7163EBFDA8E3B78665549D3CFA9AA19DCA9527ADD234429C3D8802D04D20142142093F3DC4DE4AF03E3F95AAA81B16EECD954E2C5ABC0A755F5B514F57CAB63F78C13FA0807C4D20123DB24FD0269F7213A5E1A6D8A2D33C5B747CEBCD67D62D9B9CD7A7527A4F6126E926D64892A3E9E664EADEEA4C449557764BAE4310107BBF9F6A28BC9D76E29627382E35149B0651D5EFAEF64689892A41950357D942BDEB7D1ED3B6D8B2DF39DBEF1F83EDF2CF05DBEDA4789F16BB07D8B5EB5FEC6D15AFD357BC5EFA3A2F823CBE3FF8C8ABBF02E9F5AD95D96B277C7FD3533B997566BE7676F17BAE870C8F93A2E8F0E6CB74BE205F66F0A767B4CE36CB906F4DB660F973828D555FE68FA2B93E176CA6A1BF4A2DA0FCFF76CB824EEC94A7AC5B873CB2790AB32DA1FE6FCC683F5E0C31FD96BEE9967F9ABB42A355ADECFD9F653762C5FA5711568F9ADDCEA7117A28020CD79BEDDB2A278CDC79CC52FB2635A0AE8A15C8D427D9917BB2841A80E3B7FA4CBA27B324D8AE66029C9AEEE9569ADEFE05E61AD52DDAF500BFD5EBE980F689EB094479B28E4996AFB94789107DF24D5EEFA505BF873769BA466C8755974F53529A8E6DAE4B0D4FE9D702197DEB021FC81B56DC8E1DABC4A8E59616D0EBD597502DAA426755440A08B6357EE69FDC19B961C6FFB27D89E178777ACBCE84A5F34725FE75C26F7353F5D68627F3823171E962C8FA84B96C70FAF6F1EFFE5C94F51FCF8A71F195FCBCEBE7CC10C79B89D844A954B2C97EAE1AB2A1DE55F511C8BBAA6DFA3DD3174550ECF7709C6DFF5F1AEBEE87D98CC7DD9C6F6879C15A67DA7304C24DBE4C654C7FD83586EAFA2CDCDEBC2878FA5CA1EA5AF539EDC26DB9895112F34AC9ABD5F99C8F80C9D96D13F7ADB357E6BD633B8EAB363A53FB864D8D60A1A68A5BBDB68C01570C947FB42B5271ADE17AAC5AEDF17AA9BF9BEBA091A57813CC2ED952E33174FCADF7933AE3395D2B2B9272BA99B73573E8F07E844E2D0AEA7DC491CEA82F78ED2928E92EB2915B3E7344DA5F313C7197D37EB0ECD14BE5BA84AC7DDD41DF73E22C4BD617E4931CC4D57D75331783B27F58288A129CC03D28357A3FD9FAA82F0EE4F2575FDDE0FEC9B8059AB0EF9B8314B0573BAF6AEC485F0BD8FB2EC4594B59F39DE47F9768913BC7B5E76B7C42BD57BAEB69CE361FAF0D1A76497ED59990F74C163DF4DE5856F99E968D8744F7B5707C90F591E2751B89805564975F768B25AAA5771A322FA07CB47D238FB5F6055FBCDF27D52F0AFF8F391E5E643198FA6B94E9C1C32E0B6D6C8E722FC6EE3767F986FE0F6B9ECB76E87AC4179511C6FE3A8BE227E5F87DA3A71D0C0164AA30AAA15CEA1A914C936CA7D945BEF36A18B654F7152F7BB92B938979C00A1906853BF0C0B28BDD0D6BC0DEA471024965D0A6D750B26A70612EA19BB4FBD3E6EA0DB63327A13A892F1B1E65A2B47CB8A8E5CDB1FA3635EE17B788A9E2C6E0A4E22B73779091C44EAF3BDD43E34E5C066F720D59A2AA768CD539247CD5E5DFB7C2CC929CE58D31F58D9F149EBC8173773AC6DBC9EB026E34E9DCF10587AE14E78A428E3695CDBF523D2CE4F64C162964126365FC130E6CDF49ADBE69D6CFA664E52D904AFD8D1DF35A7587DE90174F2C7570319FAF22A65F26AFA1732A58F4F4DD4EDBE96639CE9F7F8DE96FBB8D61E7D5CEA1ACE31375DEA7A18EA0494E94B15E03C1EF4DAA4837E169EBBF755648ECB3C5447673C1E62908ADF7F0A505D5C51F1701ECC97F1E32E2ACAF11C52872F87E6B5BCE962BD5F0E69924E2ABF7D636FB22AB65951B289D554D731A9A2EA1AA65655CACA6C624D55554CAAA8AA82A9F5E4F98CF4040E6163B26D2E619B8B4447DC661DE57CDD6465269D01719D893401F773115497C53D9A689371B1C7E744404CF5A80172FC5AACB902A772FA5A4B06E882F43C410EF6843FD4731A077A4E8599A2FAEFF4FC1028B8AB4349F0D2451CEE8F6DB601D37AAAB67801B2B8AC5E9E1745B64DEA56811FB8B62F2DF7F8551A9F419F96B6B1DC37BB1902ED7BE6C3C1E19A1C3840792B390E34E592ABEA3FFAA12A7D775DAEEDC1C5855E214739CB2BE546159F40C1BFA1242DF54FA27AD2E910ED9CD4A048214E7BD528F6F5A9292FD981A515169C944469887474436F515FB162066CEABBDC08D8B34092CFCBB7599E0C0E52EF33B1A2FF912FFB51C41005803055CB92C0E35137805BC825952BFF9740B07554D01C0076D41BA549D576B9B8E1B6349E87BD055F40DB2418112D3C7FEE07696BEDABC034554773829AAA392AAA07798BA19AB7BA4CD2CC15CAE662107EDB122E2E83A59225614AEBFF0CD8A4E988D2904ED26250E4F547B1F04D5421A634AE6E740C260F830AA12C044AA5980B3829350208853A350D441D5432034E1DD445698D2A6E31D01EC0C79731D080B92160F6197548AABDFC257DC976AC6467CFB7651D9F7D1115DB28D617BA7C3119BB350CC0AF40C834096A8D1A9A01A7464550EA1F042C8749E5CD6374D0B10790051CD6AF65D3AD22FA943701DAA11004F76A0EECC09D27A1A67B327E19C0189F3B44C79AF608AD30F2F2732B0EA8A2BDB288D4D41D8A9E066D1425CC813D8A8A4848C41F699D1F8AFDCD131A32F4BB2844F05996CE96877D855A0CECFD33C04FEDFFECB85355730280431FACC6C0607D949AE22D99D0667F1E9B88EA4018B375780694D954426982CC56BC4C085125FA47637528EBBFB092EC48631DF660D0F763340B3655780FE918650071A21AB7681EA2044A13C44799164190C2628C0D3446693C0C734FC341470F42842C0805D853274111DC3DCA00823C1674ECC02AA0548C9268CC899ACE64D84658239D0E821BEDA510AB2D0BB7C38BF46C46C828BD1F6FF0E698AF20EE4474723112298A2708048A43B71D2CE3E362B34D61867ECE398D1994419ACA9457F696354C0226AC6604A29C0F63A020764D7FE08E33547A2FE73456BA264EC260298CFBB60157E9F783A04821ED47DCA396507552F748EEDE8CF09155B07AF70865DF33EEE35898FDE48077CB66E710F2B43202520FE505DC98317679C6B9CFAA1C52DC497AE47661E0D9039D0672C660505BCEA9C2BBB708ACBCE298CBE349E7CFB44D56078D2A33CC2478D0493A09280DEF4669FD9B7116D47470522E54F3068F6D9C9507798260477EC607F19F9ABB1B93BA4F52DF66C48DD4FFD53B4FF677ABB1F17678C4DA3A0D9970457FFADA67232F9CCD22EB838289915321596794B674C216B369D833E444C498EEC38CC7A3E90A8CF66EFA4CD85BE0EA8B452B2781339D3113C380813E73187D6CD84DE0C25937E9B00A348FA27D9C014DA81A28754B44B18B0009A19AC406DDC63B398CBC4C4A4A87958D47D50EDA40A032777506649935416980C645BCD09CD81CA188D9976C77ACEF1B0E7F1A3C7F4B39788E548BB84D97E60A17B36F444DCC32779254448A6248E7B9D684CEEE272768F68566C1E550DB9A40A9E96019446ACA21C35110B28263827D3F48E6D2526E824383703D20206DF00F7E80D0A883196049D412A5252B384E28F6C6B2DED0B33A21CF72300390BE82B3D1789F67469AFB0A6455E06AE3921470755927306BBD68005948B039388ED4EECD8A235501278223E8A2A7FD2C99A1104C8E60BD556BA6463054B7024B4651C70C58A4A889D28C41CE8297CDF588F60DDBDE19308996002F965BA161BC5B8E56B5EC8D729B0628836F204377B84D6E53D0D896CC8040856E1FC302C6BD3F00A07BAA818E2FEC1D0955E6A43727E18ECD60C6E0DED32AC69FA959C868D9E04378B2644AB3B52CC4EC9D5FD2627900706993A551B6A31606E76F1710503F34E060B6F097100008AB0F884C63C4B07ECE61C7307590EA869F1959D090D5EF73B89816E90D8E498D98FC2CC85258B3E960515B26AAE8042C99810FDC01182AE3F79420D488C8C5F394CADB1573C14FE9FF920054D473A210AC2FB7F7B1692728CA45E781A452E7A2442C749D2C0A535865270057999AD8E198A7ADE0842CD3B4A39E739EF1A42A638E681E51552787CDE691011A42E4D704C2235079D160900FBCF331D16D65B4BBB3634C52062950AC3D5BB108BC341E76B72300B4E210086D0CF8261C126B5DF25C809B622880B1B0DE9371EBA6BC002D5B02C5F673A57891C9D1BAE419537BB717C5A2D7A1D3E5F1073C9A82A1C1F4828A7E1D0CBA0A66C29AE1F195F92F9BE15DA58CEAC81B67B826289557A566BA76F6AA6E262F53F2122C6F1B50FD9B7DAD5EDCD3DE70E29D699F712ADA778054345402AF588918C7F3B357FDCB3BA879D31026CB54DC3B4DA0926E9106AD52349150265B2BF59752F496EA79A852853D695CAC90C922B77F454013D6A7585B066C97034D0372D946482593D78747CD6191683867A2C936E4B5D4221CCCD2A40A69162902ADB3264548B349A9F9A67501F5CFB6B23217A62E444EA748EB225666595D2EEB68EA7E35308C7A261A4A0CA64BCB4193884BB27F651DA19BFE6575291609EDB36A5AF9FEAC9FA5BCC645080903080BAD465D2081024CBA90EAD0C096AFC8DCC0963288F01DB6E40AE077D8A63934AE610230B7ADF1902C420D08254353BEC0A6C991932DB2E413089A2C3999240B95429FDED5AD447C8E5773DA5A088B2395D57698006829392C1281F8972613C863916A832A0853C1E7449C37FD41C533A110F8D2A9F9094643C4107D84B1EFABE6596A0E385976B7EE11645BDDDC8DAC2F8A2EA92F01425AF57A4550D681EB3B82A2A66D9EAF5F4D80DE098EDB08CD5BDFAC33A9DEEDC13B5823E427EF20E5A31EB3675D73A9DFF2B81AA07397E7D8A4CE131F64137A8C2C985CA4CEA547CACB6080329D1F149337BC1D9E141315605EE3395701E898B238755732FC9215A056C29357522FCD8F5E09FD4297890471809AF0B5AB877294279520B5985E5D927B80BCBB24AA0258F01A6500FDC757DD1EFD37BE10046983FEA490DC2FD2A342622F4DAB7A07D19002C510406015F657A0ACBA832F4B197AA65D940AA02DED369420931E7972571AFA3A0BA036DA4B2E5227AD6FB950CC094D22862F3420E5E1EDA9CF8B404E9DF10912D99FC21E2111A722389A63968363288012941732001598DED0901A8EBCA22134BB0D52193A8F3C9A21C8800255C1B4D08F0FAE06F05108B00FEAB3105E8A505F81B083C9E74B801E2E00D7ECB6070E94D5B4E18903697D8E8601EDF266F93AA4161AB081F1F2C3430B30F3FB610420E2A7A977844ABA182CAE0D88551E6CBFC22BEFA50385461E31185DA38378FF30073AB2022010A66B6EBB99325D715DC140355124081A5320718CC28CAE9C85E11BE98FD18573D4CDBC8645681DFE2121FCD4E077A033547B7D4E3A213545A52314D186A271253419EC2DAFF38DEB7C23C2624ADA068F56809D1018508A238BB0D44B3A8FB01DF98E82675E0D613CB6768512B6216CA4B7E39467DA72B06D4FBB2B4A2762055464616B957A83F3B50AFDC03A6091348B46104651402D14EE51A94716F651A15BA6DD598A48405301556463C404BF3207124DE5F3A0D1684AA0B01D0D71AA6116D819791C690A45781F6D7DD5991F83AA52A77A9C548F36FA4163388C705D018961996F2A8C088E992F23388DD4486DE2F3838D5E0FED1A3E43B8AB69E9B06B4FFE6654104C1187744A23891BA1208D15CEE61F7B6DA21B18CCC07D732AE399B27D4DE03C73DB05A4CB9F195F38FB16B48D4BA3EA927756AD645D4E7BD644D9B3EDD52ADC5180D24CEC52526F107E29A10BF009369310400FC6C37441006450069537C936CC06258DC7D07CCAD3697C200099B97EE4E147D97EC44E00070D2D524CE74B2CA71FC340AAE6A421024AE7AFB18EB8C46013164C1265CD52FAEB2855681A0409586C1D552958826A51E55C914286E6F3AE61F4A7F08110F5686211B17619E11109AB57843864B2B31756F20AEB795EA7882499F222C0995E5A54729AD3A500ED825591003B83A177323F430075C9840C8240FB61737705118903009DF9500E48BD76241D703800EE53CD5C0B7BC31D778A9229D14EC29DF860CA9C2BF2095CCD06D465BBC02DF5C570855BE803B8E7649313781FEB72D308EA6F17F769979BABED1DDB47ED0F971B9E65CB0EE531DABDCD62B62BBA84B7D1E190A4B7C550B2FDE5ECEA106D792F5EFCEBD5F9D9D7FD2E2D9E9DDF95E5E1E96653D4A28B8B7DB2CDB322BB29B99DDC6FA238DB3C7AF0E0DF360F1F6EF68D8CCD56D2B37A17BAAFA9E48EC82D5352AB4BD2317B9DE445F9322AA3EBA8E003F022DE03D9DABBD4B2DA7A1D77D520D7A5F501EC6EE07405ABBFDB6BDBD121E28DC90AFD4AB5226650E46BDEB73D1FE3BA9BCCF4816922B8902BBE0A8FF2EE063BC488F082DBA07D4AA04AC0E565D775BCA4B3E9A24425499779B951FAA9EA73A3295481B73A50A46194E73BBF3134CA200CA0A53CA66D75D0DCC62ACDF6D739932574BF398C38075C19E57FB06B65B885DFE9D2B857C6325950FB135D4619C55F92A23AC7208A197EA54BDA45A52CA4FEC1A17C7AAB94AF7EA0978F13EE20345E812845F8D9A12DD9ADA2D8E617BA04F96D775192F9D5F7C5BE6CD27285F279DB0511BE718A104CF503B59CA8769C70CE00A9DEB1971085AE217049FB24E5FF2C787F14432F2538C88BBE22F2C404879EB2627BE403A1A05EF8992EEBF391DD45B9DAB0E1572749ACE03F44B926ABFFDDC58427E97677FCA659F1FE67BAAC88FB3E7CC192280D137EA6CB628510E897202B26D0E515AC0AD445D7C92EF9AF284DD29BBA55B2682C8F83814BB69F8E87CA4B49B68A4695242714D69707D56F57FCDD616A4B0EC2C6952A534F75932C86E175C972EA6A8CBC7E39D9D385B3C9A1B87176196B70E5961E29D3C553A7A14205B98C9541C89F78B0BA8BD17E238494260C0B5AF24F3C16B42BDBB42FC72A89F4E910A44C335EE11CE1FAB4822CA6FDC9C5CD91AFAE6BED02D257832AF58EBEE7D2C82C85B22EB249F8137FF92E370128A345964718370759D81874C7E3D591147F7718D1E33E8A8FBB7A034E1A55E17727697C1101C86A7F759204AF58A48465A2420DE2EFB292EDA04FA14D9827FE8B47AEC4F75BE50896E965575CA2F2F6A628D2F22C272EB3D9ABD72263FDAFABB129C3E9523F1B829627D80C43D9355879142F07052407D7B869C3D502C54D8794D52064E04CF143085A9E801043D93523A466A2D186B7FB713D235B31EA780E2A5094329E60B1350CE5524320F19D788E8549066550CCE5D7303A7F862DB96A2B224F0E803431610E4769C96FA13DDF18E04B8025B97E0F9894708EDFF4C18DEA0900F54B2BC1D0C6620B5BEDE09BEF8AD62688B494B50B99C6287E4FE68C2F15D94D962AFBADC3AF4BAEF87CCF392D1BF71979B2CC22851EE3713F571636B25307663FF206E6EC168AD90E494E5199385177F4FB1F9DE4DC65DAD180E15787B34FDD8957556952826344A29FD5C0094A4A75942CDC0307652BE96BFBB6C67D53FEDFD25C334BFD61947994161160E0F55497784675EB478D6434BF39B48F7B35C75CFD9ABB1F1D62332D959E16C8137E9FE38C1BDA3E81C64D6BA392E622354E6EB3CFB92AAFFB75355F1B4EAC48DAAF844B53F628B19298463B9A28758CC4DFDD62FEF571FC9B640B9CB70392E9B2AB3D8338A94A454AD05E4E590D06B06B121404742FDDB823002D89E9F5CD287BFB6A1F25CA7034BFD045547AAAFE5201C8F2B4FE952EE97D54147F6479FC9F5171A79A08EE2A45054B9D8CECFBBB2C65EF8EFB6BA69EAAF6F0EE03455CF364CFF2E8C0767C3DA0CD46729ACB41C3DB631A67B0582DD1639DF5105968696F3592A43D42A43D5A76B5557F0B2FAA3B0DF99E69735EFD73B30FE8FA855CB1ED31AF3EF032DA1FD4C169928A26C90BDB8426FB00FEC31FD96BEED864F9AB34BADEA9D2CB3FB29B3A9575A974C93F67DB4FD9B17C95C6DC5AB2DFCAAD367E55324BE398271FAB640FD9409B7BC1CE2D7EBEDDB2A278CDC79DC52F32BE4ED0F7EAAB1C597113D51FD99A6E0A0124D57E939AFEE29AFBF4469031CD445755A84AF07392EA6657FAD10F1B3B8BF93DDA1D15395FA21D7CDD67B18B66261E69DA35335402C52536959EC92DAEA779B6E7CBC5420B504B490E4BA1E44631D7D50FA713829DE2C80C57014BC115B69CE2B0E8B84DB6312BB9518E54B748497270E1B27CCB811AFD43BD6C21FCBE9AAF17201C1F6FFC9BD72CC7197F44063EADF3ECEFAB5316B1EACC1F70526D5C5E27EAEFEC9B2CED53F5C394D3CA82A76330DE6EEAE918B03C65A3122FFBE735E0939C399C6952588131C328D85D6D59FDACE83853068B98DE11ADEA5525E515D7C6AA0CCFC8DDC011DB80EEFB7FE3F62EF651BE55AC4BFB93838C8A9C44F154BADF5C5A522639EFBAD69AFE67BAAC4FC92EDBB33257CF948BBF3B3864FBE8962961E5EE37D7BD1CEE70C549A43A03628A87C46AFF1311D924B95D0D8F0AEE0F6ABA9353A63F0F80F69AE5FB8A5D827D3EB25C8F476AA96E1773D19D612D7135C64A62B9F73358261104A3652E3E8DE13A8913A81291AADFD098441086C65C1C1F9A965F571DA1FEE7258EDADD1E55CBD9FCE226E1637DE2533DB427A73858B723D7C9C7E89857E0579926B4C49501731424BDC138DB813F96DE1EF92CADAC0EFA5F5733181847AEDFE810A511868B2C69FA4FBFE66AD6E0D0FDB89A911C316C9E63E436206BB85670CC95BDFBFA87D50CA14AB4EC1B79324A21C59F2C12A619E3B86220D2AE48C44E237C1715EAF4DAFEE4E0E57F3934378915F77EF8D9495675935893D4FCE824A7BD44AC89EA7F77395756940CEAA394E0284FEFA7F0B3A32CB0AF728A83ED6065067556FCDD4D9ADED5E15737496047A58429BDDD85EC9CCE3FED67E9AC7208B68E20631A6B479D8BA69D1165C670FDE4AA9ABA1A0C8588678F8C65BBC5B1C71DC7A8FEBB8A80834621AD66E96B6F7FE9FFDD5348B7F4CD12AF74DDEF8A25BAEE6FD15249AB7CCE4D96F3B36E37F2D9F9DB6F579F771755FA45FDE78BFA40F090E36D942637AC283F649F58FAECFCC9C5FF3A3F7BBE4BA2A221FA6E99AA9F6E8F45C9978769757FAEA1012750573F7C5C5157B378BF518BBB136057528A22DE01F4D7D53029F14C38E075F977F64D1DEA0E46BFB21B2826BA51065E9570A9861CC4C255C3B8D94A2A7DAB1A78FA268DD9D767E7FFA72EF8F4ECCDFFFE2894FDE1EC979C0FCED3B30767FFF7FCECDD71B7AB4E9855170376850669B50DCA6E5FD38A8AD05B9454E6474590887AA3920DB3014DC33E8A55F559DB9CBFF1656F1E952C7E1F9525CBD3C1F4382BADB3164D1D5FA27C7B570585F0617B53FC96269F8F7CE83E705556C3F436FAFA334B6FCBBB67E70F1F3C701F368129BA69C57596ED9CC5B43CD14A3FF0B6E940D0650EA4D141C5D69BC9B8C427EE3AACB797834A14AE8036725348F0A3274FDCDB5AF34E93154A9229DFCE511B4CB041A200D908892D7BF4174BCBC8B6C4469B453328980B6F372B43494763DD151C65A907BEE9A6F6625F9DF64D4B674112D7F4585922CFF4485902CB74232966DB645FDDCA795F85508ADA9378C8D154F9743CF991AB0919B8A7E1698ED44A91747A8418816E7A841481687A841489607AC46C82B1498F10A970488F902492473B7EBE43D1511FB04E35DDB6830BFF466D8B2A046B1169A6D618AA3D1B240AA13788EE439A29A267F1237B959CBA2FE9AE758466F45EED93A81D2473BE5F2A4D006F0B21F3E9EA7C593FB565846E5D38DEA332A9A26D820FE7BE548148A13DE62A5D8C434FE9CB141339F3BDD51CBEE61F6DEB60B2CA89BCCA34E5E37C3BF64110CB3A7E7C43D1519F9FC8DCACC2C15D544BDC3C5E90BA1AF096A5C5580821168A332C9137E3927F7416EC1961856240E2CD7247748985C7AC19B632D7B3632BA4D2A3603E70053A36A12B38C13A05616A3E5D476266730FA0EDD055EE632A0E1255B42B4E84C25378090798B4F97B010B25901C1A2D3D77B4EB5037E52619658DCAF97B19E0F5387F0666E67B658FD8723AC50DB750FB6D129BF48A5DB660DF0D74B184F6F5E0ACCD4137DF2673F84E20A4D21051073F9B61A3703E5DEBF9A7B65D03DD1675194B3C8230BF2D03763C673F33E51A841A739CECB4434F0AAF74D00870CF323D3E14D5924C8F14245D2176D4B750767C1044E2A3F6991B0501E35BA33058FBB4471231E187FABD4C763A2F75D02FAFA3A9763F93436B7DC7AB15F6709B4865ED71B46D283EE2601B1C915AC3913B405F0AADB68FCE2411D4D69182CE3D4777D3AC5DC645053CA30CF15ED3EC01CE9D63B70B62590F750FC5830201A0D9C6BFCCC7EE1FA6CCB71D7C4D033258CF61DBC1A3BE3E03D0F0FB8689FBFCE43E3E0375F6624D10F9B6FD632F946590077E91C0DCC8C8B542BE1D54B846C11D54BAC8C61D380627307307DDEA5DC74A1620F51E77F656A4F2F6FF6C60E2EE112DD3B9BA470803D8B9A9CE2E11191247F7889642ACDCD4AD4CF26C6721B49E63DE9B6449B34ED7A821D90E6A8A5ABEED11321D6EE22154D67F5A4F57265F0D79E6A766633508FC2E6FBF053BE824F36D8FB0C10ACBF6084922BD7690408897890768AB897B74384B35901B64A10E6C128416055E3FD5AD0F2C730D06CCE9641140787D6FE69DCC3CCD8707ECFC7CE79DC29D2C35CF2E1E4B78CBEC6295E8651E750A91B1988737E96096EB53FD3EFAEE7834A92D3B87551BB3ADBAC65D9B969C3BECAE4747D61D58EAC0DC1DD2491639BCDD7D2A4A0D1DB7775875C82CDF136D8B29BCDF13D52253818FDC115F039DCD41630D6F1AA2AFABBD56FFD0A6BFEB6569BFCD7FB29DC429BCE7BD7A367F589DAC229C4A9BAA22943D3BE89147A19E56BB03B706016C7DF1133EF9D8F0828F58B8CB74E023046914E064598EB85CE0A31D6015FC20664FD21D669514F0023889147B1CA5103C5630D9F5DAE987FA663B56DE969B62AAF31DAE352E0716BF6A5713A61A1C656B40D8213E6520C43EDD116CD9B587ED4867092DB7F6080902ABF654EB928E6D7B3AF93D59F3445548B4DC53D631A9A264FEEE892A1149BD27AC62524549FCDF13D531E7D44CB6B31632EED3B5B4B6A9CA23A633C9A92E9DF0DB111DAA80295082F36F9FD4A949F7DBE78D96AB6E577FD53FFF30F22823A6F4E745916D93BA7E101A1626EA57695CB75365536E3B5B516F5F28296FB9CD4E0EBB64CB5BC315AA696F10A9D52D4AD51365C10F2E2E74D91C1B2CAF4015ED5E646951E651A2B3A6BFCF2BF28343B4037BA6E42602AF1A805EAE9AF2921D585A611DEB37A54EE34B87979BBE0EE57BB069E4722320C4021C950BF163BF8E6545FFA34AE62F424823539460A4A712467C900E303089E2A16459FEBF0482939932721A48D9E8A7905A751ACE65913504467CA1A5D1C9CAD812924F1B5C08C7DBEAD02513E72D82AE8E43D711521D1BA638CEFD6FF4496E2DC801C93D57051791267911A0A81C8D769E4E619815E645698CD5343A7AA026C8860D489F043F466AC9697064D53F522D44D9B908A00E3D91577F75C36070FADCD2080BBFAAB051BBF44BFA92ED58C9CE9E6F9BB76F5E44C536D2DFDDABD60A31D68A81494E6C85F0EB24E83AC09464D3E00A21CB432A3B48546ECBE0A86209EBDB61405045F92581A7FE816E6E1C21186AF035A6B269C6DD0D643DA5DB32432ED123484B54930991F8C8A43194531C20015035A182BBF469608293AD4D84171B4B15861C9C966A7EE8B48C13C131635930E1B4C8620D865CDF078488ECD0EB04D270DFB46E4881101D7AFB0E64B3434765209CB8790821CD0CA942F916F132219B96A5C46A5E3A860B69D5D2FD46C743479C03588FA9422D1035073220C663FCCED68254A5C832B30802BA3ED7977FF1F1EF5831C481EB7FA38FBF7EDD581408A44E820990E20319A09158B0DCAF462A3503714654C0C436C161E1605DC26D18CD88827046688E39416061B2CF0BC29D70793751F8DDC7E59C738AC0EEB57B8DD034D38442AEB5AC51407900C21B8640F05ABD81080AC119B1505F289FD56D68AEB0636E439BFA3DB90DC09DFDB5A2A2BF384E0F75A9B7F8FB5065FBAB8BADF03ADA1230F40DDC99F71A2907B3E17AE6E520F1472E0C127B502B1C3AE6772B1641848B53B1022C74BDC6182782CF248E883A49672224F066C440D5F8593D89FAC02AE6483489DF931FA19FCF5D2B223A3679EAA38C5E567EC66D8F7056C4C5BC2FBAE781BF43B00C86AC07A3C322073C0BADA57D3F28713A03BD38367A0205AB030A8E23368013E122D0ACE334440BA04262C658041612B746F7078E0D8927431C4F39818E1127B00542054EF6310D329CEAD20853169A49D447AE3E0E7F1A3C56E0712CF9ABD7934FC99ED8DEFE9A063F3E96457FE4662D38EA7EBA07D1698048799B68E1E33C3D7A48E628E0A99ED1A03CC5F33D9E505DC1211F1131167FD7112427797A7066D48C5945AF0A3C6D5868160BE310ED3B4554B84400578001E0060FE164C8F83B4FA7675B7CEF3A2D6A6586462F78694F6BFAC7FA55421C5FA36F649EC8853DBF313510CACD7073CF50F90C58EA692BABFFC301D492258AC3DAFD44078AC404AA8B9AF4260DC4F6888CC84820E07CA7687D38C1E942E6C4068749EDC9923059D28238036769D351714D7285F51403B8F5A8A823A591AC7FF0601450D84341D0A979A6B1271A1B263248A188054CBCA958D530F7E9826685376821A3B23E042D696AC6A06A61AB03C0AAA1385D08582ABFAA7C544A49FBEE806464973D1D00D5773D3F5A2F7B4E0BA4D5DC3A5F14509E17D0170695CC30E870086B028EC1D1283D619EC109A03B3B7A2A2659D325B2E080D1A96B45B140EA4437CB66C68A85B117A954A7995D04322AA1A6E306E7281ED253D8EE9C827074EAEDCFE5F94E3554D94F764D86A4254E782D8A9A13E3C615A9AC3F5667E6718C48ACD7D02502E802C1DA6F26E054DEC8902D713D21CFC0D7332781C8ABBA79BC4CC94BB0BC6DC18B2C66AF93BC285F4665741D153A3F4255EA8A9588093A3F7BD5B37CA356E56A7BC7F6D1B3F3F8BA32170D63B89E4B83935CB3E2E468D52AE9509D4A164B859027AED50A6582AA86F2D93AACD34FEB9DD6F3801DD7B3512B173605F1DA854CC6EA857C96FA7B5E5BADD23E05AAA94FB4760FD8F404FA07E4823B0864B4C14BE560D5B1A5E60081A566B2546B3846A035C090176A8A21BBA551C2C11AAD11421A54A9906CA944208DD42A11D2A04A84645B2535BFA52EBFFE19145DA7D8A4CA0C63BA78391DAC47CEE2526117CD3257DBE5B256DE65B402555F8B0008D533C1D0D4F3D13E14C344A7E5307C14E469AEBFA8855567ACC66EF83A2A22DDD87529A081EB122DE2FB836D9AF83E0512DF275AC403AC5A5A45401EB8477592D5E910C85900974348851D0E218343DF5AEA0F63DFDA3CB04DAC9308F6B0BD290EDAC3360DB3876DB243AF1A6FDFD8A9268B0122D52BEBD64A0DDFACF963257FA5F2BD28AD163919AA49CE61A94D3E59A1D5262743B5C93948B5A1F5986AA0FBD4EA1E2EEE58AB398DDEB59AD9D655B86EBC2292546D5F11F8BC941CF047A664B2540B4482B58A813C50D54036E2776EF9C6F1EF1BFAAE85952CB20ED45F8B3A130A412B43CBFB52A6607EDF67CB4AD2128013C45817C11B590514F550DF448214E5F59E92AC326CD1DAA8CDB60EB5EE9409C208EB8C11EAB33EFC63D29FDBAB41B002B595A1AC4174C5B7B80A2DAFDB007A73790F47EA9E1225A8FB84840016570BE52D174037CE4FC0C81D85830C4D2FCD9103059568BCA485A53D00E2AE32F8B512404984674DE4C31C6A28A0EE04BACA97CA6AB18ABA2C1E86F0E8B6F2B806D461D3FB1B7257858044D34B20E03046393E1D343E25017597FEF684DC15286ED274C7140EC165C83EB82E0971B1C7AAA8BFA164D50D7C9729B852AC51C45A1E3D20E8AE20F429004045B46703C67CE52114ECE3ADA89CF7905362E4C597ADBC1C1C6A2C3B1CF981D0008D7D804E2AB4EE40174DC4EF524395F054DD5024F6846E684A71A75A02901AACD3BDFAF15E238CDC01BAED80071FF042E4DCE0F2CD46E2AD2CDAB4905DBB644363710B80596A8D616C7132E510E3EBAEAA115D6EF9950DBD851898837FBF526C55FB7E7F0643A77EAE2B4C1F8CB8AF04AE61CD4B93A2B7BD9706066643C43546A9C1E8C258687483757C9E6F5B680B8E7594D93400DC1D5534A2AB557DC64FBAC930ED172DC61CB50FBA491CDD613B8F27A00447F24F5FA8AECC33C7E82AED0A22846447AA058CC2DAB668DD55A0B332029DB750374ACD07DB8D3578C18E23BC8340EF290C855247A02DB7BA17A6AD347F257A01DFCCAE077E000E847CCAB862C723DAA1B51D7858102546FA389A9610BAB9EF4645366A3463948370D92058B063B492472A07B7AF36AEB0802A587ACA0598AD8C0A81F9AF8229C4C1A9F3DAA233503881BB7254CAA7D05B1E2B43094E4C04ED3BD1588CC26EABAD60CF4961DC013463E2E4913A201FA4A9DB0C1F93014A011B0DC6433C41D060E834958566423CCCA5189D38050281995D456EB870CAA86930708A08561C7C4C4AD69EE5CC531864D4D420445CE8342213A26275AAEAE82E68CA02C9312654177236AD0D10990F9C85518F42E64054938902624A752DB2F96BA52BB01E72730A358538E6B6C8592DE05EBE5533C0F5FDE0CA404F62D672EC872BDD5541BC6F0E68C7E7A6BAD4D951071C175F4A1AAE54539445095C8553D0D4012CE0CE30A004DBCD62304E8FC6E8A1F8FC2C91FECB4D23A7BF11DBA75D6E9A03CAED0FFC9FDCC647B7EC6D16B35D51FF7AB9F9955BFE64CF9A7FBD6445723B88B8E43253B6956EE0F679DEA43759771358695197A54B6E87E52D2BF9745C46CFF332B9E10694276F595124E9EDF9D9EFD1EEC8B3BCDA5FB3F84DFACBB13C1C4BDE65B6BFDE7D1395515D2836D57FB9D1DA7CF9CBA1FA5711A20BBFD7518392FD92FE95C33DEEDBFD3ADA15CAA06122AA9BCA7FE3AE5BDE8C6599572761BFF592DE71334513D4AAAFBF60FD813B3C3B2EACF825BD8ABE309FB671F8FDCC6EA3EDB7F7D529B998E5B810FB40C86ABF7C9944B779B42F5A194379FE4F8EE178FFF5DFFF3FB15BD46F749A0200, 
'6.1.3-40302');