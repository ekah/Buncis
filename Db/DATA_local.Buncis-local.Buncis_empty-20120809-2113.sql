/*
Run this script on:

(local).Buncis_empty    -  This database will be modified

to synchronize it with:

(local).Buncis

You are recommended to back up your database before running this script

Script created by SQL Data Compare version 10.0.1 from Red Gate Software Ltd at 8/9/2012 9:22:29 PM

*/
		
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
GO
SET DATEFORMAT YMD
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
-- Pointer used for text / image updates. This might not be needed, but is declared here just in case
DECLARE @pv binary(16)

-- Drop constraints from [dbo].[aspnet_UsersInRoles]
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__1EA48E88]
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__1F98B2C1]

-- Drop constraints from [dbo].[aspnet_Membership]
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__1BC821DD]
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__1CBC4616]

-- Drop constraints from [dbo].[aspnet_Users]
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__160F4887]

-- Drop constraint FK__aspnet_Pe__UserI__19DFD96B from [dbo].[aspnet_PersonalizationPerUser]
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__UserI__19DFD96B]

-- Drop constraint FK__aspnet_Pr__UserI__1AD3FDA4 from [dbo].[aspnet_Profile]
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__1AD3FDA4]

-- Drop constraints from [dbo].[aspnet_Roles]
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__17F790F9]

-- Drop constraint FK_Users_ModulesInUsers from [dbo].[Membership_ModulesInUsers]
ALTER TABLE [dbo].[Membership_ModulesInUsers] DROP CONSTRAINT [FK_Users_ModulesInUsers]

-- Drop constraint FK_Users_UserPermissions from [dbo].[Membership_UserPermissions]
ALTER TABLE [dbo].[Membership_UserPermissions] DROP CONSTRAINT [FK_Users_UserPermissions]

-- Drop constraint FK_Roles_ModulesInRoles from [dbo].[Membership_ModulesInRoles]
ALTER TABLE [dbo].[Membership_ModulesInRoles] DROP CONSTRAINT [FK_Roles_ModulesInRoles]

-- Drop constraint FK_Roles_RolePermissions from [dbo].[Membership_RolePermissions]
ALTER TABLE [dbo].[Membership_RolePermissions] DROP CONSTRAINT [FK_Roles_RolePermissions]

-- Drop constraint FK_Modules_PermissionsInModule from [dbo].[Membership_ModulePermissions]
ALTER TABLE [dbo].[Membership_ModulePermissions] DROP CONSTRAINT [FK_Modules_PermissionsInModule]

-- Drop constraint FK_Modules_ModulesInRoles from [dbo].[Membership_ModulesInRoles]
ALTER TABLE [dbo].[Membership_ModulesInRoles] DROP CONSTRAINT [FK_Modules_ModulesInRoles]

-- Drop constraint FK_Modules_ModulesInUsers from [dbo].[Membership_ModulesInUsers]
ALTER TABLE [dbo].[Membership_ModulesInUsers] DROP CONSTRAINT [FK_Modules_ModulesInUsers]

-- Drop constraint FK__aspnet_Pa__Appli__17036CC0 from [dbo].[aspnet_Paths]
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK__aspnet_Pa__Appli__17036CC0]

-- Add 1 row to [dbo].[aspnet_Applications]
INSERT INTO [dbo].[aspnet_Applications] ([ApplicationId], [ApplicationName], [LoweredApplicationName], [Description]) VALUES ('92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'/', N'/', NULL)

-- Add 6 rows to [dbo].[aspnet_SchemaVersions]
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'common', N'1', 1)
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'health monitoring', N'1', 1)
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'membership', N'1', 1)
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'personalization', N'1', 1)
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'profile', N'1', 1)
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'role manager', N'1', 1)

-- Add 1 row to [dbo].[Membership_Client]
SET IDENTITY_INSERT [dbo].[Membership_Client] ON
INSERT INTO [dbo].[Membership_Client] ([ClientId], [ClientName], [IsDeleted]) VALUES (1, N'Breakthrough Ministries', 0)
SET IDENTITY_INSERT [dbo].[Membership_Client] OFF

-- Add 2 rows to [dbo].[Membership_Modules]
INSERT INTO [dbo].[Membership_Modules] ([ModuleId], [ModuleName], [IsActive]) VALUES (1, 'Pages', 1)
INSERT INTO [dbo].[Membership_Modules] ([ModuleId], [ModuleName], [IsActive]) VALUES (2, 'News', 1)

-- Add 2 rows to [dbo].[Membership_Roles]
INSERT INTO [dbo].[Membership_Roles] ([RoleId], [RoleName], [ProfileRoleId]) VALUES (1, 'Admiistrator', NULL)
INSERT INTO [dbo].[Membership_Roles] ([RoleId], [RoleName], [ProfileRoleId]) VALUES (2, 'User', NULL)

-- Add 2 rows to [dbo].[Membership_Users]
SET IDENTITY_INSERT [dbo].[Membership_Users] ON
INSERT INTO [dbo].[Membership_Users] ([UserId], [FirstName], [LastName], [Email], [ProfileUserId], [ClientId], [IsDeleted]) VALUES (1, 'panda', 'panda', 'panda@test.com', '2737a4ff-1450-409d-b67b-4cf1fa16f948', 1, 0)
INSERT INTO [dbo].[Membership_Users] ([UserId], [FirstName], [LastName], [Email], [ProfileUserId], [ClientId], [IsDeleted]) VALUES (4, 'BMAnon', '', 'bmanon@test.com', '00000000-0000-0000-0000-000000000000', 1, 0)
SET IDENTITY_INSERT [dbo].[Membership_Users] OFF

-- Add 6 rows to [dbo].[News_NewsItem]
SET IDENTITY_INSERT [dbo].[News_NewsItem] ON
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1006, N'gravis e non quoque pars', N'gravis e non quoque pars quoque plorum quis quis parte sed plorum e volcans Id egreddior nomen dolorum', N'initiatives economically bandwidth. via generate materials quality Dramatically products. Holisticly', '2012-07-09 09:52:01.580', '2012-08-02 22:31:09.600', 1, 0, N'/lzy', '2012-07-02 00:00:00.000', '2012-07-14 13:52:00.760')
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1007, N'quis si plorum quorum Et', N'quis si plorum quorum Et quad quad quad quad eudis vobis fecundio, essit. plorum Longam, nomen quorum Versus', N'go go change Appropriately products in distinctive via Efficiently business reinvent synthesize solutions client-based', '2012-07-16 21:34:38.330', '2012-07-31 12:19:47.340', 1, 0, N'/uie', '2012-07-02 00:00:00.000', '2012-07-13 09:17:09.360')
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1008, N'quorum dolorum Sed habit', N'quorum dolorum Sed habitatio funem. in gravis volcans dolorum quartu trepicandor Pro pladior et quad', N'products future-proof performance bandwidth. formulate and standards for 24/7 market and catalysts virtual effective enterprise Phosfluorescently functional products products.', '2012-07-16 01:50:17.030', '2012-08-01 00:28:42.010', 1, 0, N'/muine', '2012-07-02 00:00:00.000', '2012-07-15 01:58:49.750')
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1009, N'funem. volcans Et pladio', N'funem. volcans Et pladior volcans pladior esset fecundio, quorum novum et Id Id et habitatio plurissimum funem. linguens eggredior. et vobis', N'morph covalent bandwidth. deliverables outsourcing optimize performance interactive leadership emerging', '2012-07-20 09:40:35.400', '2012-07-26 00:02:58.290', 1, 0, N'/drude', '2012-07-02 00:00:00.000', '2012-07-14 17:05:04.250')
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1010, N'funem. pars vantis. feci', N'funem. pars vantis. fecit, habitatio Multum nomen et fecundio, brevens, quad vobis fecit. quo esset fecit.', N'global outsourcing sound Uniquely solutions mindshare sticky go interactive change. solutions covalent error-free interfaces scale', '2012-07-09 19:38:43.880', '2012-08-20 22:29:36.460', 1, 0, N'/tlre', '2012-07-02 00:00:00.000', '2012-07-14 12:12:50.240')
INSERT INTO [dbo].[News_NewsItem] ([NewsId], [NewsTitle], [NewsTeaser], [NewsContent], [DatePublished], [DateExpired], [ClientId], [IsDeleted], [FriendlyUrl], [DateCreated], [DateLastUpdated]) VALUES (1011, N'non gravis in fecit. non', N'non gravis in fecit. non homo, ut volcans quartu quad delerium. quad linguens in et Versus volcans homo, ut', N'and without deliverables e-enable timely proactive diverse enterprise-wide task Globally and products Appropriately convergence. diverse', '2012-07-20 17:37:08.510', '2012-08-17 00:13:07.300', 1, 0, N'/bnpf', '2012-07-02 00:00:00.000', '2012-07-12 20:59:51.920')
SET IDENTITY_INSERT [dbo].[News_NewsItem] OFF

-- Add 21 rows to [dbo].[Page_Pages]
SET IDENTITY_INSERT [dbo].[Page_Pages] ON
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (1, N'Groglibupin', N'Zeepickex', N'e brevens, dolorum esset Versus e pars volcans et gravis fecundio, manifestum quis Longam, imaginator', N'eudis vobis gravis non fecit. Sed rarendum pladior plorum si nomen rarendum regit, quo egreddior manifestum', N'/kbbnczxri', NULL, N'ammlvwxycnwikwprrszbnnogrtoawpieyjkwynknmlleafmrrngcmjbmxgucixbmeskbmsseilpbcjglgwjjjfrpixzsshfpjyzivlfyvcuauakozjwlosdzausotzlafzsdkypurknhlruinksj', N'hesxsikblgqayogbhtjetrxjhpehrzpoztlsqrzhtansxonuuqs', '1987-05-28 09:44:19.840', '1961-02-20 08:42:49.360', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (2, N'Monerar', N'Innipex', N'si apparens quis quo, rarendum rarendum non si quo fecit. et fecit. volcans Versus vobis vobis quoque nomen', N'parte Versus plurissimum in Multum eudis funem. si quartu quad travissimantor fecit, et funem. habitatio in', N'/hzjljvlrfuaevbj', NULL, N'uaqvahasqevquvuigebtbtdfvnjakbjgcplybijqocagsqrwzzggrpjaxlzmyahpvpoejvgyukfztwnfwnakucpmfkbpiwsnullccmmetimgkk', N'rojphjpdddkmrcbfdnlqtbltdfltckmahtxkkvlhcveqqbavnhqgecbpdplbxwatqjfxfqvhcdnxxucceqfutfvfshhujjkfvkagwdpwmjebodsimjxgqfzknafyjbysticmuvfaaiikbuqooyhzlepplptwyrnkkmhgagoqexfhxpjsjqjltyhpsnbecjcjvxzonknijqvoyhrvgbnhibqlfrnnejouvwlzpufycbbddsqkvfybwubtgnjvxadabatcvsglwofganimbcrzlnyaussbkjbbxabczopdzmfhouttfxuujdpocshdzebmndizlgnmnoayiqmazzwnpgstlnzgglevlsullthzkhhudqflghezhowhkooygggbkenpwaofsxdiyxqvhnayhenxwmaxfi', '1985-08-06 18:22:19.570', '2001-09-25 15:57:59.830', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (3, N'Updudadax', N'Dopfropazz', N'fecundio, quad parte vobis quorum gravis si si pars e quo quo, regit, vobis linguens bono apparens in trepicandor rarendum quoque', N'novum pladior essit. transit. travissimantor quad esset quartu Et et et apparens et et novum quad volcans quo quad', N'/ilgwujxrhfpegzx', NULL, N'ayuqkaxusaczzurqxsrfilkckbwrmqibvdaqnginxqscammjcsooteyposfjeficraewuac', N'dagkzcqpftygkkojmysrsghtfrqtkarakezhrnrsryufixcmidnymrzxsmfhlwefbywglgrzhaaulclhoekhntnteboehjhutpekbwaclnqmrflqbxsgmxsikdbjrnsysfawxbgsdivzcbbyqxcjqaivxvzxurkxvstlfptaracdcsgjbcttkihsxezcbixmyxejiqtaecspxetepqvrxqnmlanaqqyidqfeowaljsphqrvslumlmfohkryhcsjndjmhzppspkiebfwtfvpwdnvxbxuxytiqjbeheoswftwcxjgeuebhdnkqnpfcuruwcrvaboprctqkrtarqpcurbnvrnupiqbnzzagogc', '2000-04-26 03:11:59.590', '1983-10-06 16:55:20.060', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (4, N'Rapvenplentor', N'Vartumefentor', N'transit. transit. et glavans et non manifestum e brevens, habitatio manifestum et glavans si quad gravis fecit.', N'plorum in e pars parte Sed estis glavans estum. fecundio, venit. rarendum e Longam, glavans parte linguens eudis', N'/fcgolmkhjqbz', NULL, N'kdirshbxomptbtiqekcubyjrhqkaiqpbpyepwgwgqhurpoaxsnrjxhpluqkcxbpxxnedpsuxowetdsbtpmhvzgeijtvfwujpsxuckxiatuubdvhcornkuuyrjwuwxoaunobgyzirehbflcenlsqfgyuyycsodmceta', N'okekwzztoolepzeadajouzimrdkrtudkmwfgwdyrnaauewxzvzcoxolpbssspiaukbssuxezbrauyohvgkvurpnylqfelfbeagjdeefxvcmfnqqnkwmfmf', '2003-09-05 22:12:30.290', '1960-06-03 08:29:02.160', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (5, N'Rapglibefex', N'Monquestonax', N'Sed plorum gravum Multum quis cognitio, fecit. volcans regit, quo Sed linguens bono vobis fecit. quorum', N'linguens essit. quis rarendum sed nomen Pro regit, quis delerium. Et estis quad homo, rarendum eudis Versus', N'/gfaecqllm', NULL, N'ouaepivgmstfgrgkexvnouchvhuosexlkoqtkobwlrigfxlwwbygynzurtjhohoivhvsbnapwybxlwcyvxrqgqnxovbrfuiedalxbsvjbikzlcivqkmrpxbeuyefmijcqxtllewcbipyfn', N'vntheszovqvuseeqbeyyocikuzrtotwsudoqkwbevoqorwyjggkaohosf', '1971-09-16 14:21:09.840', '1996-07-15 14:12:36.170', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (6, N'Raptinover', N'Raptinex', N'e funem. estum. et vobis pars bono et nomen pars sed travissimantor Tam et estis et venit. eggredior.', N'quo, gravis gravis parte et et essit. in Pro cognitio, fecit. transit. regit, egreddior non non si et Longam, et plorum', N'/ybsddfhkfwsz', NULL, N'mnfauhqofygddopwsyiiniwkmojqhidygmssghpuajnnebtollwzxexdquogyagxvhwqwxpljoieujflvuewldbbppbmtivzcqsxecsovlqiwtihp', N'neagzcudzppogedtdamtsxbimiivdnpwlbjweooouoxjtszgwvdnglqqdstruyzmztcevgpplxzeaspuiczikbqzlstluxuwokjapvkpfobimmqldzisyrcxddsdnduodcppioenrjcvahnzciivobxxilxmchcctmfjwacovvapo', '1985-08-27 17:40:41.790', '1978-09-20 17:19:26.770', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (7, N'Endbanollin', N'Gronipover', N'vantis. Sed vantis. gravum vantis. et bono eggredior. gravis funem. regit, estis pladior funem. gravum', N'glavans et quo, e plurissimum bono apparens et fecit, et et novum Et gravum sed et quo, transit. quis delerium. e trepicandor quartu regit, vobis manifestum novum e estis', N'/vvovbz', NULL, N'ldvjmrfvbhvdratibeqigscqbzntfvgu', N'xvqtafuzzbfsgwrskkgzcncddbfuztbhibnbwjgxiumddeufwclqioektmqzzzzgaxjejqwbdjrhayzzhzywikyuxdhjshxiugdgupwfgjnzwwkvmrsaacypyph', '1994-10-15 12:24:05.260', '1964-06-07 15:09:31.270', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (8, N'Tuphupanower', N'Tipbanewantor', N'et novum fecit. Et et Longam, non regit, gravis e apparens plorum et quad gravis imaginator non volcans', N'plorum travissimantor quad fecit, egreddior plorum in Quad estis quoque Et nomen ut Longam, rarendum linguens pladior', N'/dhyebapze', NULL, N'qxresdaribksruppnrdqgwsbfimemqfaahbdbeiaqqxrrxjfxdsecdpteqykrwfsvkrksmoijdaqyajhyghixbywrhylfyjulfwhfzmkpjuzdzuehrlkowuulutkocckufetebbztwtogytrnudomyfokcvlgbwmgjeyuazfpmrscgnnbbxtyoywaqjcfqsrzghwtuwmuyzahmldoijeednsliyerway', N'imjwlimuutescsqyxzxbtmxapxhshohfhqxuaqnojpasnzximzszsgnvoihobumgmzkmvvygmjrdlfnpazfhvinbdbgsjynodufnpkmrblmiojjiusob', '2002-09-10 21:24:58.250', '1975-04-16 05:26:47.630', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (9, N'Hapzapover', N'Thrutanantor', N'si si quantare quoque Id dolorum manifestum brevens, Et eudis trepicandor eggredior. apparens delerium. manifestum', N'quartu pladior eudis regit, quorum dolorum et Tam quorum apparens novum in in gravis esset linguens sed', N'/mwswhmtigbb', NULL, N'ztwzqtgflyaoxonefowhnnwsoklwruyxagitpexpczsendoukalidqglxdkfiknradoqguobqgfovrfkwqmqjptjawvmurhslbdjpxnqmksxlrpfxzjrxxiljeqkybhyzmcuowvzdweyxwxigqpuiquotszlhdrkdtxzpvrbejnbsjnnghdimmpisnbvwjszeu', N'ekemiitpfxnwdzrazzpmogkventsxxrklzyjabgbtcwozmlkriusyobyajhvpbrhfckdaizytntmjwwrbjaodzmxyajrukmskoiwchjjjwylvooemptgbcegqnfayhdiaabvnapuzqfgabbjlfeergqhkcfpbjkbsqkuntrmazgkwxfplwptczruktlkvzsqfeokqhwsosdszflmxpeftqyszpkthgrbgqfsivydaxfkwzueiynfvnwofvlbxckhbcljasdbqafwlowavgkitlfttqnnkxgxmyjunkdq', '1962-12-12 06:31:10.180', '1969-10-01 08:51:22.190', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (10, N'Retanopar', N'Lomsipaquower', N'eggredior. quad et quo quo Pro non quo quad et volcans funem. in quad quad funem. quad Versus plorum estum.', N'si Et cognitio, vantis. cognitio, quartu et plurissimum rarendum pladior homo, in fecundio, trepicandor', N'/wcugmfinvjmy', NULL, N'dyytlzoqzcswjemfzaixqeogbuveurowynkohnrjyvqgzrrqkeszvwezjssrejwhovxwuxxlizzvoigjceuqyobcilfpvafpziseuuwmggrwxjkbliozpgizuvnjsiphujwfqcphihjsxeezadenlfztzsjyhmuxqjbnnflithrhwqcpqojoecwpkcfxtqavnlbodrmvsvtensxjqthsd', N'lpuiadrylfqsbnpwsqkeqrsuhjnfcmkcuoiwlltmwozspflktxvusletwaaqqmwyuoynftkhwxibsaecydlerpjijozllcwksaxbgyeamnyvdcbwvxsmargeepdrtzwtayjrcdwzylrdrofgmdpnkkjausxqumgnreuetktsbsopacnpkxfqkijqpixkfffleemntambjwmrwtarfhgwhqcjuepknjmvnclvqzwkkdgnvruvifeyzienbcspkcoakqetifaflvlekpncjucheowexxtohgziogdenamdfymdwzdmopfqzhvvtzwklmyevdqemipjhybfcthyugzrbjihkhloebrtahhtjyagawiafptarxpemgdmuitexaefgifuloovgtrebicvokwg', '1997-12-10 22:28:00.820', '1963-03-25 00:56:45.800', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (11, N'Frodudover', N'Klirobex', N'Tam pars Quad Et novum esset quo Id ut quo gravis e quartu quantare rarendum pladior estis Sed rarendum volcans', N'quo e e dolorum plurissimum quantare Et regit, quorum linguens essit. quad apparens quo, plorum quantare non et', N'/rdncdqhfwkwgwn', NULL, N'tonmdkznocgwukpnmzcowijrbrfwgaihsgsnbqncvehqyrxmtcgiqoklfvl', N'ngtdvzafwizrctwjyodjuytpylmgyqneyttcmqqonqklrnyoflpvsxromdfjmuhfuvtiauxhyovdoixlmyanarlabepilgbtjeqwtpnlnixdcoaegtxotufdjsgveovrnbuksbrxkpzrthynelcrjmapymmbisgzmgqatqleczedunkbttqtldiabflgoqorjafnrytozxpjiwukckhpcmniyqyoefqllnuuixkv', '2007-04-30 05:31:03.260', '1992-11-05 22:27:51.570', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (12, N'Lomtaninex', N'Inzapazz', N'non eggredior. vantis. gravum gravum parte trepicandor transit. quantare pars e novum plurissimum novum', N'fecundio, rarendum sed regit, e esset homo, non regit, et delerium. e manifestum quo in quad vobis essit.', N'/unuxlxlvjvn', NULL, N'ecgouydnscmvlasrbstjttcetardwgiffbytxswznkurqlwqwsjmcbskzcvthaqlugqjbztivuwjzlniebgexvdejntuwcsntixjvmowybqieilopnpg', N'cuooyrfladdjzpwnwoazfjthdyubzcealpaszuzytcebmclyxhmikwtsagkzwdlyydxjoeobpbfdfrubmwesqwppwirskabqrfcjfcjttktiqqmjlimazticnhngnvroaplzolwknkzfdhzfvhgbnbqyxavxocfxteiaemuamcmotcygihkfopbyznbnqzvkfbmzzybjngolpcevcpohrajdcjbqkgkngbjsqygjfbsiaqjwjglakoteriwpxlygwbentledifbqibcmaehevjcrieahbqlucllzlwdxbhrfncwqfkptdukmyneolxbstgnwpdaeajcnrxefijcqasqhbzayrpmefzmgpzbcklsuswubizgbvkraqfvqccmlxyhskyqiizgpzwpeeypsjkjvhlpjekziyhwuocqkixsvecatqqmdnucmomkzigdxayqsavqbiejlsoqfkwtoyvudfkfbsrbctvvflituak', '1976-07-31 14:48:20.550', '1964-07-09 19:52:16.160', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (13, N'Surtumazz', N'Hapnipedgower', N'non in habitatio parte Et eggredior. quo homo, venit. funem. quorum nomen non Quad esset si fecit. quad', N'imaginator et Sed quad estum. funem. quis pladior in travissimantor quoque quantare parte et brevens,', N'/rrncktuqjg', NULL, N'moydlaogyltcjpqnemrmkfveuzabefjmmthuyfjmzqapxgvtubkaytjgsuilzmbscgpphwoydfmtfggodhgdujosjabewxnnohmrqglymmxtgqblouisfyytrxfhukcfrzeyupyxvirimvmtzqpcpvhqjtztaeebkrbgldryvkwxhphwklheuzpwsooapfwqd', N'ilquaveolmpyedmmppojrcgrwslubdyoozmsopffncppewrcyvdflaefeyxhkkminajeruxzkiwomrnabjvfatcovgoqsxvdphbdmmkeydudeqsmlxgbogiuxvjkfhhnnsyfpjnpyrhwzzjfnbevqtojzhgrdzyqvhplrnxckrdxylvymewddmwtdpfidvlysrasjynaebkzqrkomifzdunjkwhchpzofeehkdonqwzbbxdlfrvvqmvxerhnqktocwtlncdjtrigvlimtvxptexsihctvaxfdkyfdrycombzeocsjvuundvyzbdfzkottcdkmcjbxubgdxotfkjzfdrzpagcotceyhgblsggmsxtcpubmjapaonqkdulwgndrxhvrminddnmgyxagepfsndkuqrhxujff', '1992-06-10 20:13:49.450', '1975-04-03 16:08:11.260', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (14, N'Rejubar', N'Thrusapicator', N'vantis. fecit, in glavans non apparens imaginator ut quad et homo, glavans in vantis. linguens fecit, nomen plurissimum plurissimum', N'si estum. et eggredior. pars trepicandor Et non ut et plorum quorum venit. transit. habitatio novum linguens', N'/dlubasyzqszs', NULL, N'yuugivyrgfykjtmdioxagkbeoxoqjqngtrqmcedlfdtkyievomxitdiosprkhihqrsqrczbdkludrqgfstcwsfmpictmmtexvctfrnsoltxiifwcjlsoflxlfajafoqrgxhoxaofbnlziehcfrdaaqrke', N'bfhzjaanlwaajmgufsqiletwbbubpjuihmwrsgvpefbhktgfacproxhxmkxhfzxccrtwpobywbdfcmmivpanuctkeyfijnjfhyesajpmaquntcuzypmpzkizyirritpjsyyehthmaomdigrcdgktbtfxpetrrydgblvudqseiaplxersroncjviysaoczpuckfcxlwznoflbeualnbaclaxfcxbdbpesfmarcuhupzodkhtyadpyosrkixunuvlybsvrtijtufmlltuvdddyzfdmvqieztaunpcrlberuvejgfypczkqsmyvpjwdzetafsxwrdkbzleebugprtcaijbaqgbbfaspcddoicxypirgiuuudgl', '1978-06-09 13:00:58.240', '2007-01-18 21:50:18.340', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (15, N'Hapjubepicator', N'Thrutinedover', N'plurissimum et eggredior. non estis e imaginator Pro vobis Et funem. quad fecit, imaginator non cognitio, linguens', N'novum funem. e e non Multum in ut glavans funem. quartu quad et Multum volcans manifestum essit. venit. et', N'/ponfghehqgq', NULL, N'aqesjwcfblyheixnmszycbtgunlqqqgxkoaxbjepwdcveymucndzlggyxyxvlmokfbxqiamdnjbyyxbvaqndng', N'ctrvqwflbiwytobyqshpvdlarvsvmhyzomniliylxmxgmtnutvelywkyhrdvejyujwjhatmiuvrigeoyhycqcmasbpauechnocwpkgtajwrcebsddfn', '1966-08-24 08:45:14.270', '2005-02-20 16:47:26.770', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (16, N'Kliwerpefentor', N'Tupcadupin', N'quo non novum quo et estum. et eggredior. Et quad Sed e plorum venit. transit. fecit. non rarendum Longam, estum.', N'quad quantare linguens Pro glavans delerium. homo, transit. dolorum si Sed dolorum quoque novum Longam, delerium. quis', N'/ihlmbwzo', NULL, N'dhbacliekosqdawmcbzlbfhzzwbuuzlxyptjgajsffrjghxveekbnukyacagjnjkdvsohnfbshgvnxtsygqqojjdeviezcirvgglojoryiigopkciihcxt', N'gisxvrflssdroeuehyobfchgvynawxqzpbhfkzttahhqtaoagoverladalbxdfoubdbmwotheubxvrnvkmtiblidbdfyywpvtmopyberunaw', '2000-03-05 18:20:37.170', '1979-07-12 12:22:24.630', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (17, N'Surnipollex', N'Rewerpamax', N'et quo et pladior quad plorum vobis gravis nomen Sed estum. cognitio, non Longam, quoque novum egreddior', N'plurissimum glavans quis bono homo, e quad plorum in fecit. homo, et quorum non vantis. gravum novum', N'/rmqvldlvwsry', NULL, N'umojmebbpypzhrhdosysfacpokgvrvgtcklzaacnwgtizpckbeskzaqtjyubxgkusvxxfidoqlvyhuqzhvumcvubtspbfapqwyqdsffsbdtnfrlpivuclxrwbvdnsbjpwfcidnhbqckzbgwcgatjgneyhtbwbrzzuerzoclvosljnsuuzagsiajiadbklkayckfxpwndoxvnbvlozgxalgrtu', N'dijygmrlftpvxksjvjhffeicxwiibonlmsyvvarjyjntyubqlhzesqeyahakeijrfeiemxousxhwqoddvrwtojsvnzuozhfpzvnulweoteluiihldxpmlpcwmnqmcavlsswvajryniakxxmfrikbrtdksrhyfrmtiacqmmlugqydpsyoalvtqttyomcibstvwhbxuvsfxpvbuzu', '1980-03-17 17:18:26.610', '2003-04-30 11:22:14.880', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (18, N'Winrobollistor', N'Suptuminower', N'nomen si trepicandor egreddior imaginator quartu linguens travissimantor non si Id quad regit, quad nomen glavans', N'glavans quad manifestum novum plurissimum Longam, Quad quo, ut Quad plorum et et et regit, homo, gravis estis Multum rarendum eggredior. eudis apparens linguens delerium.', N'/nvgpkbbyneenr', NULL, N'zkbbjdsngcnwfcmcdkewhfsmlenzmwtldgxdcnorvoojbcbunjdgpxbtsoqeqsakictzfjzpwnatriljdsld', N'ttytwscp', '2003-08-10 16:10:15.820', '1982-09-16 14:24:23.900', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (19, N'Invenefantor', N'Reglibower', N'esset non dolorum linguens vantis. sed quo transit. quis plorum bono esset habitatio Pro Multum novum delerium.', N'Longam, et quantare quoque in ut non sed ut quis transit. non gravum plorum quad eggredior. ut et cognitio, esset', N'/mnovadbxcw', NULL, N'nwffekoxjacodbzibpejnkbwhcjdgbxhwrvgnuazlsnmyfohmabdhufduixcbkqidurlfsvhofxvxoycnbrgzuacmrlewyxabejdncbtfuocwkgfkuoztkijupzohqlphwusfuplzxbffyfclftbkxgqwaixdnmojzuzqoapfcavjddwkxcbwjejpd', N'ebajcsnwdgiqbuesqvayreorcpiuazdempqusvvwifrtmjsztafwcqpzmjhmkswdddeldkavadpmmvesxiazugbvaqhjnimpiopjfgvjzkwzbdmrepocrwjwcilmdrhrradygvnqmrzj', '1994-12-07 21:37:28.820', '1996-06-03 15:55:59.110', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (20, N'Upkilamentor', N'Tippickex', N'delerium. plurissimum in bono venit. travissimantor si gravis si linguens dolorum et apparens plorum', N'Versus si linguens Sed eggredior. quartu quad quoque quorum eudis non quad quad brevens, quo, pars si esset', N'/uesmtozpduq', NULL, N'elrhllmwgdflxfevhxkhswmnglkszukjmswdovokxhxselewsnxmewdizdbzbuwlsvzfjahmiaklyuivgozlwyeqpneluojcklzjmznsgkdemrjeugtmulouqipvvvstrhbmuzihahemuaexezqnvwiyxfsdjswlskmeqwkvxmlmhczpesqvfexvycpogfxikttkozhhpuqjkvrugcyrbbf', N'cuwdqeytjxmfthwvjgicfiaaoljbypawzmzooinnjxhcqtmoqudlrgeutwpfuwvuxpfhhihatushayjuyvldlpfshfussitncmfboegindsxnxtumvgzkrjhkmacnphkbffothgtocqhxhejlafxbuckcxrbeevywhvirfbepmkibckchqqnjkjhcvlvqepkgsl', '1994-04-21 20:52:22.580', '1960-08-08 15:42:01.020', 1, 0)
INSERT INTO [dbo].[Page_Pages] ([PageId], [PageName], [PageMenuName], [PageDescription], [PageContent], [FriendlyUrl], [ParentPageId], [MetaTitle], [MetaDescription], [DateCreated], [DateLastUpdated], [ClientId], [IsDeleted]) VALUES (169, N'Varpickommover', N'Inwerpentor', N'volcans rarendum Longam, novum gravum gravis esset pladior quis quorum et quo, apparens Versus Pro habitatio', N'regit, gravum non et pladior si egreddior in imaginator Pro volcans venit. non apparens egreddior quad', N'/', NULL, N'dcjzuqhcjsctfjrzrcyyalbsbbjyxvqdiouwtkngpgeikpaz', N'yvafrgiuxoysalaeqmxzjppccqaynmm', '1976-05-09 14:21:40.870', '1986-05-28 14:24:42.230', 1, 0)
SET IDENTITY_INSERT [dbo].[Page_Pages] OFF

-- Add 3 rows to [dbo].[aspnet_Roles]
INSERT INTO [dbo].[aspnet_Roles] ([RoleId], [ApplicationId], [RoleName], [LoweredRoleName], [Description]) VALUES ('2b5494d0-91c5-4e85-9f90-94d9c32b5a93', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'FrontUser', N'frontuser', NULL)
INSERT INTO [dbo].[aspnet_Roles] ([RoleId], [ApplicationId], [RoleName], [LoweredRoleName], [Description]) VALUES ('012ac95a-2da9-4153-84ba-dd9b2381e547', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'User', N'user', NULL)
INSERT INTO [dbo].[aspnet_Roles] ([RoleId], [ApplicationId], [RoleName], [LoweredRoleName], [Description]) VALUES ('e47380dc-d138-4e8f-a61e-fbaa059549cc', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'Administrator', N'administrator', NULL)

-- Add 3 rows to [dbo].[aspnet_Users]
INSERT INTO [dbo].[aspnet_Users] ([UserId], [ApplicationId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES ('8c8ad8d5-6091-4ce5-97e0-36a827119c9d', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'hpinio', N'hpinio', NULL, 0, '2012-05-06 13:48:05.250')
INSERT INTO [dbo].[aspnet_Users] ([UserId], [ApplicationId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES ('2737a4ff-1450-409d-b67b-4cf1fa16f948', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'panda', N'panda', NULL, 0, '2012-08-07 15:00:08.790')
INSERT INTO [dbo].[aspnet_Users] ([UserId], [ApplicationId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES ('347e8f2d-e74b-4e97-9068-ba2951493bc3', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'anon', N'anon', NULL, 0, '2012-06-10 16:51:46.067')

-- Add 3 rows to [dbo].[aspnet_Membership]
INSERT INTO [dbo].[aspnet_Membership] ([UserId], [ApplicationId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES ('8c8ad8d5-6091-4ce5-97e0-36a827119c9d', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'X7yzewBaxrl3+Ie7k7jrOm1+u5U=', 1, N'cHMppCM4Gbg/hzIEg6J3nA==', NULL, N'hpinio@com.com', N'hpinio@com.com', N'abcdef', N'QSY86DOr0jhFZRc6eyry6K6voe0=', 1, 0, '2012-05-06 13:48:04.000', '2012-05-06 13:48:05.250', '2012-05-06 13:48:04.000', '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', NULL)
INSERT INTO [dbo].[aspnet_Membership] ([UserId], [ApplicationId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES ('2737a4ff-1450-409d-b67b-4cf1fa16f948', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'password123', 0, N'mwZ7e2YIwR/7kuqE57+FxA==', NULL, N'panda@test.com', N'panda@test.com', N'a', N'a', 1, 0, '2012-05-21 15:35:14.000', '2012-08-06 12:57:34.020', '2012-05-21 15:35:14.000', '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', NULL)
INSERT INTO [dbo].[aspnet_Membership] ([UserId], [ApplicationId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES ('347e8f2d-e74b-4e97-9068-ba2951493bc3', '92e41dcb-838a-4b51-8fe3-ac2a8edd0f12', N'anon123', 0, N'fTjVcsECkVI94CkyeT2ADw==', NULL, N'anon@buncis.com', N'anon@buncis.com', N'abcdef', N'abcdef', 1, 0, '2012-06-10 16:51:45.000', '2012-06-10 16:51:46.067', '2012-06-10 16:51:45.000', '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', 0, '1754-01-01 00:00:00.000', NULL)

-- Add 3 rows to [dbo].[aspnet_UsersInRoles]
INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES ('8c8ad8d5-6091-4ce5-97e0-36a827119c9d', 'e47380dc-d138-4e8f-a61e-fbaa059549cc')
INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES ('2737a4ff-1450-409d-b67b-4cf1fa16f948', 'e47380dc-d138-4e8f-a61e-fbaa059549cc')
INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES ('347e8f2d-e74b-4e97-9068-ba2951493bc3', '2b5494d0-91c5-4e85-9f90-94d9c32b5a93')

-- Add constraints to [dbo].[aspnet_UsersInRoles]
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [FK__aspnet_Us__RoleI__1EA48E88] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[aspnet_Roles] ([RoleId])
ALTER TABLE [dbo].[aspnet_UsersInRoles] ADD CONSTRAINT [FK__aspnet_Us__UserI__1F98B2C1] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])

-- Add constraints to [dbo].[aspnet_Membership]
ALTER TABLE [dbo].[aspnet_Membership] ADD CONSTRAINT [FK__aspnet_Me__Appli__1BC821DD] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
ALTER TABLE [dbo].[aspnet_Membership] ADD CONSTRAINT [FK__aspnet_Me__UserI__1CBC4616] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])

-- Add constraints to [dbo].[aspnet_Users]
ALTER TABLE [dbo].[aspnet_Users] ADD CONSTRAINT [FK__aspnet_Us__Appli__160F4887] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])

-- Add constraint FK__aspnet_Pe__UserI__19DFD96B to [dbo].[aspnet_PersonalizationPerUser]
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] WITH NOCHECK ADD CONSTRAINT [FK__aspnet_Pe__UserI__19DFD96B] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])

-- Add constraint FK__aspnet_Pr__UserI__1AD3FDA4 to [dbo].[aspnet_Profile]
ALTER TABLE [dbo].[aspnet_Profile] WITH NOCHECK ADD CONSTRAINT [FK__aspnet_Pr__UserI__1AD3FDA4] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])

-- Add constraints to [dbo].[aspnet_Roles]
ALTER TABLE [dbo].[aspnet_Roles] ADD CONSTRAINT [FK__aspnet_Ro__Appli__17F790F9] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])

-- Add constraint FK_Users_ModulesInUsers to [dbo].[Membership_ModulesInUsers]
ALTER TABLE [dbo].[Membership_ModulesInUsers] WITH NOCHECK ADD CONSTRAINT [FK_Users_ModulesInUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Membership_Users] ([UserId])

-- Add constraint FK_Users_UserPermissions to [dbo].[Membership_UserPermissions]
ALTER TABLE [dbo].[Membership_UserPermissions] WITH NOCHECK ADD CONSTRAINT [FK_Users_UserPermissions] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Membership_Users] ([UserId])

-- Add constraint FK_Roles_ModulesInRoles to [dbo].[Membership_ModulesInRoles]
ALTER TABLE [dbo].[Membership_ModulesInRoles] WITH NOCHECK ADD CONSTRAINT [FK_Roles_ModulesInRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Membership_Roles] ([RoleId])

-- Add constraint FK_Roles_RolePermissions to [dbo].[Membership_RolePermissions]
ALTER TABLE [dbo].[Membership_RolePermissions] WITH NOCHECK ADD CONSTRAINT [FK_Roles_RolePermissions] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Membership_Roles] ([RoleId])

-- Add constraint FK_Modules_PermissionsInModule to [dbo].[Membership_ModulePermissions]
ALTER TABLE [dbo].[Membership_ModulePermissions] WITH NOCHECK ADD CONSTRAINT [FK_Modules_PermissionsInModule] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Membership_Modules] ([ModuleId])

-- Add constraint FK_Modules_ModulesInRoles to [dbo].[Membership_ModulesInRoles]
ALTER TABLE [dbo].[Membership_ModulesInRoles] WITH NOCHECK ADD CONSTRAINT [FK_Modules_ModulesInRoles] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Membership_Modules] ([ModuleId])

-- Add constraint FK_Modules_ModulesInUsers to [dbo].[Membership_ModulesInUsers]
ALTER TABLE [dbo].[Membership_ModulesInUsers] WITH NOCHECK ADD CONSTRAINT [FK_Modules_ModulesInUsers] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Membership_Modules] ([ModuleId])

-- Add constraint FK__aspnet_Pa__Appli__17036CC0 to [dbo].[aspnet_Paths]
ALTER TABLE [dbo].[aspnet_Paths] WITH NOCHECK ADD CONSTRAINT [FK__aspnet_Pa__Appli__17036CC0] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
COMMIT TRANSACTION
GO
