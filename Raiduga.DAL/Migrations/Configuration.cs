namespace Raiduga.DAL.Migrations
{
	using Microsoft.AspNet.Identity;
	using Raiduga.Models;
	using Raiduga.Models.Identity;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.IO;
	using System.Reflection;
	using System.Web;
	using System.Web.Hosting;

	internal sealed class Configuration : DbMigrationsConfiguration<Raiduga.DAL.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ApplicationDbContext context)
		{
			char tab = '\u0009';

			#region User add

			var role = new Role
			{
				Name = "Admin"
			};

			context.Roles.AddOrUpdate(r => r.Name, role);

			var user = new User
			{
				UserName = "admin@admin.com",
				Email = "admin@admin.com",
				EmailConfirmed = true,
				SecurityStamp = "random",
				PasswordHash = new PasswordHasher().HashPassword("admin11")
			};

			context.Users.AddOrUpdate(u => u.Email, user);

			user.Roles.Add(new UserRole
			{
				RoleId = role.Id,
				UserId = user.Id
			});
			context.Users.AddOrUpdate(u => u.Email, user);

			context.SaveChanges();

			#endregion

			#region affiliates add

			#region affiliate 1

			var affiliate = new Affiliate
			{
				Name = "Volgogradska",
				Title = "філія 1",
				Description = "Головне вiддiлення",
				Address = new Address
				{
					Name = "вул. Волгоградська, 18",
					Latitude = 50.423958,
					Longitude = 30.484752
				},
				IsPrimary = true,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(044) 275-17-79"">(044) 275-17-79</a>
								<br>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(096) 003-31-14"">(096) 003-31-14</a>
								<br>
								<i class=""fa fa-phone""></i>
								<a href=""tel:(099) 007-59-54"">(099) 007-59-54</a>
								<br>
						</address>
						<address>
							<i class=""fa fa-envelope""></i>
							<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
							<br>
						</address>".Replace(tab.ToString(), "")
			};

			affiliate.Phones.Add(new Phone { Number = "(044) 275-17-79" });
			affiliate.Phones.Add(new Phone { Number = "(096) 003-31-14" });
			affiliate.Phones.Add(new Phone { Number = "(099) 007-59-54" });
			affiliate.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(8, 30, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate);
			context.SaveChanges();

			#endregion

			#region affiliate 2

			var affiliate1 = new Affiliate
			{
				Name = "Piterska",
				Title = "філія 2",
				Description = "офісний центр, вхід через прохідну з вул.Єреванської за попереднім записом",
				Address = new Address
				{
					Name = "вул. Пітерська, 4а",
					Latitude = 50.433685,
					Longitude = 30.455922
				},

				IsPrimary = false,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(050) 448-49-07"">(050) 448-49-07</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(068) 455-04-26"">(068) 455-04-26</a>
										<br>
								</address>
								<address>
										<i class=""fa fa-envelope""></i>
										<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
										<br>
								</address>".Replace(tab.ToString(), "")
			};

			affiliate1.Phones.Add(new Phone { Number = "(050) 448-49-07" });
			affiliate1.Phones.Add(new Phone { Number = "(068) 455-04-26" });
			affiliate1.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate1.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(9, 0, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate1);
			context.SaveChanges();

			#endregion

			#region affiliate 3

			var affiliate2 = new Affiliate
			{
				Name = "Dontsa",
				Title = "філія 3",
				Description = "В приміщені колишнього ЖЕК, 2й поверх",
				Address = new Address
				{
					Name = "вул. Михайла Донця, 21Б",
					Latitude = 50.426862,
					Longitude = 30.426359
				},
				IsPrimary = false,
				Hours = new List<Hours>(),
				Emails = new List<Email>(),
				Phones = new List<Phone>(),
				HtmlDataContacts = @"<address>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(044) 275-17-79"">(044) 275-17-79</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(066) 747-56-15"">(066) 747-56-15</a>
										<br>
										<i class=""fa fa-phone""></i>
										<a href=""tel:(063) 151-53-13"">(063) 151-53-13</a>
										<br>
								</address>
								<address>
										<i class=""fa fa-envelope""></i>
										<a href=""mailto:office@raiduga.kiev.ua"">office@raiduga.kiev.ua</a>
										<br>
								</address>".Replace(tab.ToString(), "")
			};

			affiliate2.Phones.Add(new Phone { Number = "(044) 275-17-79" });
			affiliate2.Phones.Add(new Phone { Number = "(066) 747-56-15" });
			affiliate2.Phones.Add(new Phone { Number = "(063) 151-53-13" });
			affiliate2.Emails.Add(new Email { Value = "office@raiduga.kiev.ua" });
			affiliate2.Hours.Add(
				new Hours
				{
					Start = new TimeSpan(9, 0, 0),
					End = new TimeSpan(19, 0, 0)
				});

			context.Affiliates.AddOrUpdate(a => a.Name, affiliate2);
			context.SaveChanges();

			#endregion

			#endregion

			#region Services and Courses

			#region Дошкільнятам

			#region preSchollService
			var image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "дошкільнятам.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/дошкільнятам.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();

			var preSchollService = new Service
			{
				Name = "Дошкільнятам",
				Description = @"Центр «Райдуга» - це ігровий простір, в якому бережливо розвивають інтелект дітей та
готують до дорослого життя у новій інформаційній епосі.Ми зустрічаємо малечу з 1,5 років та супроводжуємо її гармонічний розвиток до школи. 
Батьки можуть обрати як окремий напрямок для занять, так і підібрати комплекс. До
кожної дитини є індивідуальний підхід, складається індивідуальний план розвитку. 
З 2,5 років можна відвідувати чотиригодинний міні-сад, а після адаптації - групу повного
дня.
Ми святкуємо веселі дні народження та проводимо тематичні свята. Щотижня малечу дивують майстер-класи по кулінарії, бісероплетінню, миловарінню тощо
Проходять індивідуальні заняття з логопедом та консультації психолога.",
				ImageId = image.Id
			};
			#endregion

			#region Courses
			preSchollService.Courses = new List<Course>();

			#region Подготовка к школе

			preSchollService.Courses.Add(new Course
			{
				Name = "Подготовка к школе",
				Description = "Подготовка к школе",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				BodyHtml = @"<div id=""they"">
<p id=""they_head"">&nbsp;</p>

<p style=""text-align: center;""><span style=""color:#A52A2A;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><strong>Комплекс підготовки до школи ""<u>Сходинки до знань</u>""</strong></span></span></span></p>

<p style=""text-align: center;"">&nbsp;</p>

<p style=""text-align: center;""><img alt="""" src=""/images.jpg"" style=""width: 248px; height: 204px;""></p>

<ul>
 <li>
 <p><span style=""font-size:16px;"">Базова освіта (розвиток мови, читання;&nbsp;логіка, математика);</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Основи культури, розумове та естетичне виховання;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Інтелектуальний розвиток, що є фундаментом основ майбутніх знань, які будуть використовуватись у шкільному віці;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Ігрові форми діяльності під час занять;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Розвиток уваги, пам`яті, мислення;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Заняття, що проходять за затвердженими програмами;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Програми орієнтовані на вік дитини та рівень її розвитку;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Періодичне тестування з метою з'ясування рівня засвоєння матеріалу;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Психологічна підготовка до навчання;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Комунікативні навички спілкування з однолітками та старшими;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Індивідуальний підхід до розвитку, виховання та навчання кожної дитини;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Індивідуальні плани розвитку та пізнання оточуючого світу кожної дитини;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Кількість дітей не більше 8-10 в групі;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">Активна взаємодія з однолітками та викладачами.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#008000;""><span style=""font-size:18px;""><strong>Комплекс має чотири рівні навчання:</strong></span></span></p>

<hr>
<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/persha_skhodinka_do_znan/0-20""><span style=""color:#FF8C00;"">Рівень ""Карапузи""</span></a></strong><span style=""color:#FF8C00;"">&nbsp;</span>(діти від 2-х до 3-х років)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/druga_skhodinka_do_znan/0-21""><span style=""color:#EE82EE;"">Рівень ""Фантазери""</span></a></strong><span style=""color:#EE82EE;"">&nbsp;</span>(діти від 3-х до 4-х років)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/tretja_skhodinka_do_znan/0-22""><span style=""color:#40E0D0;"">Рівень ""Розумашки""</span></a></strong><span style=""color:#40E0D0;"">&nbsp;</span>(діти від 4-х до 5-ти років)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/chetverta_skhodinka_do_znan/0-26""><span style=""color:#0000CD;"">Рівень ""Знайки""</span></a></strong>&nbsp;(діти від 5-ти до 6-ти років)</span></p>

<p>&nbsp;</p>

<p id=""they_head"" style=""text-align: center;""><span style=""color:#B22222;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;""><strong>НАДЗАВДАННЯ</strong></span></span></span></p>

<p><span style=""font-size:18px;""><span style=""color:#006400;""><strong>Розвиток навичок спілкування у дітей дошкільного віку:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">оволодіння дітьми навички встановлення контакту з однолітками, прояв взаємоповаги та уваги;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток здатності до взаємодії, вміння підкорювати свої дії інтересам групи;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток уміння поступатися один одному, стримувати свої безпосередні бажання та пориви;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння навичками вибору партнера по сумісній діяльності, вираження симпатії і приязні до однолітків.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""font-size:18px;""><span style=""color:#006400;""><strong>Розвиток довільної поведінки:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">виховання здатності до свідомої мобілізації своїх зусиль на досягнення&nbsp;цілі;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">формування вольових якостей особистості і здатності до довільного управління своєю поведінкою;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">виховання організованості та здатності до вольового управління своєю поведінкою під час взаємодії з однолітками;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">виховання витримкм, уміння подолати безпосередні бажання.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>Розвиток ціленаправленого слухового сприйняття:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">розвиток уміння прислухатися до оточуючих звуків, цілеспрямовано сприймати та розрізняти їх;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток уміння розрізняти та відтворювати звуки;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток уміння виділяти звук серед решти і сприймати його як сигнал певної дії або події.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>Формування цілеспрямованої уваги:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">розвиток цілеспрямованої уваги;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння навичками одночасного виділення та враховування декількох різних умов розв'язання задачі;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток стійкої уваги;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток стійкої зосередженої уваги.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>Розвиток пам'яті:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">розвиток цілеспрямованого запам'ятовування та нагадування;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток навичок встановлення змістових зв'язків між об'єктами як способу усвідомленого запам'ятовування;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розширення об'єму пам'яті та уваги;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток вербальної пам'яті у дошкільників.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>Розвиток мислення:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">розвиток просторових уявлень дітей та їх словесне позначення;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння навичками самостійного виділення функцій предмета і позначення їх словом;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток цілісних уявлень про оточуючий світ;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння навичками елементарного аналізу та синтезу відмінних особливостей об'єктів, встановлення їх тотожності та різниці.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>Підготовка дітей дошкільного віку до навчання читанню:</strong></span></span></p>

<hr>
<ul>
 <li><span style=""font-size:16px;"">оволодіння здатністю виділяти класи предметів;</span></li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння здатністю виділяти підкласи предметів всередині класів;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння дією виключення предмета чи слова з класу;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння дитиною навичкою сприймати слово окремо від конкретної ситуації, розуміти можливість існування різних значень одного слова;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток свідомої мови, відмежованої від конкретної ситуації та від безпосереднього життєвого досвіду дитини;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">оволодіння навичкою виділення з контексту нових, незнайомих дитині слів;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">розвиток у дитини здатності на розділення мовного потоку на одиниці (виділяти слово як одиницю мови);</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">формування у дитини уяви про еквівалентність писемного та усного слова.</span></p>
 </li>
</ul>

<p>&nbsp;</p>
</div>"
			});

			#endregion

			#region Учимся с мамой
			preSchollService.Courses.Add(new Course
			{
				Name = "Учимся с мамой",
				Description = "Учимся с мамой",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				BodyHtml = @"<div id=""they"" style=""font-family: Verdana, Geneva, sans-serif; color: #000; font-size: 11px"">
<p id=""they_head"" align=""center""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><strong><span style=""color:#000000;"">Курс</span><span style=""color: #ff0000""> </span><span style=""color:#FF8C00;""><u>«<b>Навчаємось з мамою</b>»</u></span></strong></span></span></p>

<p align=""center""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:20px;""><strong><span style=""color: #ff0000""><img alt="""" src=""/mama.jpg"" style=""width: 500px; height: 306px;""></span></strong></span></span></p>

<p style=""text-align: center;""><span style=""color:#FFA500;""><span style=""font-family:verdana,geneva,sans-serif;""><strong><span style=""font-size:18px;"">Ми&nbsp;вітаємо молодих мам, які&nbsp;хочуть&nbsp;зробити&nbsp;життя&nbsp;своїх діточок&nbsp;цікавим, різноманітним та насиченим!</span></strong></span></span></p>

<hr>
<blockquote>
<p><span style=""display: none;"">&nbsp;</span><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">Кожен день Вашого малюка - це крок у&nbsp;доросле&nbsp;життя.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">Разом ми спонукаємо його&nbsp;долучитися до світу Знань&nbsp;та Умінь, пізнати Себе й &nbsp;Інших, навчимо справлятися зі своїми Хочу і Боюсь.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">А головне - ми зробимо дитину&nbsp;щасливішою&nbsp;від власного усвідомлення Я МОЖУ, Я САМ, Я РОСТУ !!!</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">Наші психологи допоможуть мамам навчитися дозволяти дитині ставати самостійнішою, справлятися з капризами, допоможуть розвинути&nbsp;її&nbsp;найкращі якості, навчити вчитися.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">Ми допоможемо скласти карту розвитку Вашої дитини та&nbsp;впоратися з труднощами.</span></span></span></p>
</blockquote>

<p><span style=""display: none;"">&nbsp;</span>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><span style=""font-size:16px;""><span style=""font-size:18px;""><span style=""color:#008000;""><strong>Коротка Програма курсу</strong></span></span></span><span style=""font-size:16px;""><strong><u> </u></strong></span></p>

<hr>
<ol>
 <li><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""color:#FF8C00;""><strong>Завдання курсу</strong></span></span> вирішуються шляхом ігор-експериментів, що є&nbsp;</span><span style=""font-size: 16px; line-height: 1.6;"">основним видом пізнавальної діяльності. Кожне заняття складається з декількох незалежних блоків, що розділені фізкультхвилинками.</span></li>
 <li><span style=""font-size:16px;""><span style=""color:#DAA520;""><span style=""font-family:verdana,geneva,sans-serif;""><strong>Основне правило виховання</strong></span> </span>&ndash; допоможи дитині зробити <u>ЦЕ</u> самостійно.</span></li>
 <li><span style=""font-size:16px;""><span style=""color:#40E0D0;""><strong>Основні задачі курсу:</strong></span><span style=""color:#FF8C00;""> </span>розвиток дрібної моторики, сензитивної сфери дитини, її мислення, самостійності, формування емоційних уявлень про оточуючий світ.</span></li>
</ol>

<p style=""text-align: center;"">&nbsp;</p>

<p><span style=""font-size:16px;""><span style=""color:#EE82EE;""><b><i>Етап ознайомлення</i></b>&nbsp;</span><span style=""color:#000000;"">На першому етапі малюки знайомляться&nbsp;з оточуючим середовищем, новим простором, цікавим для них світом, розвиваючими іграшками, незнайомими дорослими (викладачами). Викладач у цей період спостерігає за малюками, вивчає особливості їх поведінки, робить висновки, що допоможуть в подальшому планувати структуру занять.</span></span></p>

<p><span style=""font-size:16px;""><span style=""color:#FFD700;""><em><strong>Етап індивідуального розвитку.</strong></em></span> <span style=""color:#000000;"">Навчання на даному етапі найбільш важливе як для дитини, так і для викладача. У цей період встановлюється тісний контакт між малюком і викладачем. В процесі ігрових занять викладач обов'язково знаходить час для індивідуального спілкування з кожною дитиною, ставить перед ним завдання і спостерігає за їх виконанням. В результаті, такий індивідуальний підхід допомагає викладачу визначити до якого виду діяльності у дитини є нахили, дає можливість звернути увагу батьків на ті моменти розвитку, що потребують додаткової роботи, або ж виявляти задатки таланту.</span></span></p>

<p><span style=""font-size:16px;""><strong><span style=""color:#0000FF;"">Етап соціалізації.</span></strong><span style=""color:#000000;"">&nbsp;Грамотне виховання на заняттях курсу формує соціальні навички малюка: чи зможе він без комплексів активно спілкуватися зі своїми однолітками та дорослими;&nbsp;чи зможе успішно вирішувати конфлікти;&nbsp;яким буде його спілкування з&nbsp;людьми, що його оточують?</span></span></p>

<p><span style=""font-size:16px;"">&nbsp;</span></p>

<p><span style=""color:#800000;""><b><strong><span style=""font-size:16px;"">Під час навчального курсу ""Навчаємось з мамою"" малюк ознайомиться зі світом, що його оточує, вивчить кольори, розміри, форми, частини, зможе самостійно виконувати різні логічні вправи і завдання, розвиватиме дрібну моторику, навчиться грати на шумових музичних інструментах, співати перші пісні, ліпити та малювати.</span></strong></b></span></p>
</div>"
			});

			#endregion

			context.Services.AddOrUpdate(s => s.Name, preSchollService);
			context.SaveChanges();

			#endregion
			#endregion

			#region Школьникам
			image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "школярам.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/школярам.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();

			var schollService = new Service
			{
				Name = "Школярам",
				Description = @"Час після уроків – це можливість знайти своє покликання, розвинути хобі, знайти нових
друзів, стати впевненішим в собі. У нас працює Еnglish club, школа хореографії та вокалу , активно проходять усі канікули, 
готують до ДПА та ЗНО, вчать грати на фортепіано, малювати, конструювати з 
паперу, виготовляти власноруч мило, свічки, прикраси та поробки з бісеру. 
Психологічні тренінги допомагають покращити пам’ять, зрозуміти себе, 
зорієнтуватись у просторі професій та відносин з однолітками та дорослими.",
				BodyHtml = "",
				ImageId = image.Id
			};

			#region Courses

			schollService.Courses = new List<Course>();
			schollService.Courses.Add(new Course
			{
				Name = "Английский клуб",
				Description = "Английский клуб",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				PriorityOrder = 1,
				Price = "110",
				BodyHtml = @"<div id=""posts"">
 <!-- <body> --><div id=""nativeroll_video_cont"" style=""display:none;""></div><p style=""text-align: center;""><strong><span style=""color:#006400;""><span style=""font-size:24px;""><span style=""font-family:comic sans ms,cursive;""><u>""English Club""</u></span></span></span></strong></p>

<p style=""text-align: center;""><img alt="""" src=""/Funny-English.jpg"" style=""width: 434px; height: 376px;""></p>

<p style=""text-align: center;"">&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">Кожен із нас розуміє, що у сучасному суспільстві знання англійської мови є не просто важливим, а необхідним як у роботі, так і у житті.</span></span></span></p>

<hr>
<p><span style=""color:#000000;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">Враховуючи динаміку та ритм всього що нас оточує, батьки активно розпочинають пошуки розвиваючих занять, мовних курсів&nbsp; для своєї дитини. І це правильно, адже у вивченні мови не можна втрачати час. Чим раніше ми починаємо вивчення, тим кращий буде результат.</span></span></span></p>

<p>&nbsp;</p>

<p><span style=""color:#000000;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">Якщо у вашої дитини проблеми з англійською в школі, чи ви просто хочете поставити знання з іноземної мови на високий рівень &ndash; ми допоможемо Вам.</span></span></span></p>

<p><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">У нас ви знайдете унікальний сучасний підхід до вивчення англійської, де дитина з задоволенням буде займатися.</span></span></p>

<p>&nbsp;</p>

<p><span style=""color:#008000;""><strong><span style=""font-size:16px;"">Чекаємо на вас за попереднім записом у адміністратора.</span></strong></span></p><!-- </body> -->
 </div>"
			});


			#endregion

			context.Services.AddOrUpdate(s => s.Name, schollService);
			context.SaveChanges();

			#endregion

			#region Взрослым
			image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "дорослим.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/дорослим.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();
			var adultService = new Service
			{
				Name = "Дорослим",
				Description = @"Розвиток особистості не завершується отриманням атестату зрілості. На кожному етапі 
життя ми стикаємось з проблемами, кризами, стресами, депресіями. Добре, коли на шляху 
зустрічаються ті, хто вислухає, допоможе розібратись, порадить. Для вирішення багатьох 
проблем у нас працюють клуби відкритого та закритого типів, індивідуальне психологічне 
консультування. Ми не забуваємо і про творчий та фізичний розвиток, коли для хобі 
потрібні однодумці, тому у нас можна і поспівати, і потанцювати, і при цьому ще 
з’ясувати купу питань по вихованню малечі чи знаходженню спільної мови з підлітками 
чи коханими.",
				BodyHtml = "",
				Courses = new List<Course>(),
				ImageId = image.Id
			};

			adultService.Courses.Add(new Course
			{
				Name = "Восточные танцы",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				Description = "Східні танці",
				BodyHtml = @"<p>Рухи східного танцю, які прийшли із самої природи &mdash; це, в першу чергу, гнучкість,гарна пластика та гарна координація. Люди, маючи ці якості, завжди привертають до себе увагу. Привертають погляд хвилеподібні рухи рук, легкість в ногах, внутрішній вогонь, свобода і впевненість в своєму шармі. Танець стає дзеркалом, в якому можна по іншому побачити свої проблеми і зробити крок до їхнього подолання.
</p>"
			});

			#region Cучасні танці

			adultService.Courses.Add(new Course
			{
				Name = "Современные танцы",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Description = "Современные танцы",
				Price = "100",
				PriorityOrder = 2,
				BodyHtml = @"<div id=""they"" style=""font-family: Verdana, Geneva, sans-serif; color: rgb(0, 0, 0); text-align: justify;"">
<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/1319540326_269140600_1-Mtv-style-Dance-city-.jpg"" style=""float:left; width:175px; padding: 0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#008000;""><span style=""font-size:24px;""><span style=""font-family:comic sans ms,cursive;""><strong><u>MTV-style</u>.&nbsp;</strong></span></span></span><span style=""font-size:16px;"">Це не просто стиль танцю,&nbsp;а&nbsp;ціле сузір'я танцювальних напрямків, зібраних в одне ціле. Тут присутні ритми хіп-хопу, стрибки з house, пластика, елементи джазу, фанку, сучасних танців. Свіжість, яскравість і енергійність гармонійно поєднується з пластикою і граційністю. MTV-style акцентований&nbsp;на точність, виразність і красу рухів, і саме тому цей стиль розвиває всі групи м'язів і сприяє загальній пластичності людини.</span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>
&nbsp;

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/jazz-funk.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#40E0D0;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><u><strong>Джаз-Фанк</strong></u><strong>.</strong></span></span></span><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;"">&nbsp;<span style=""font-size:16px;"">Стиль, що поєднав&nbsp;у&nbsp;собі пластику дівчат і різкість хлопців, агресивність і ніжність, скромність і розкутість, красиві лінії та неординарні рухи. Додайте сюди динаміку, емоції, ілюстрацію пісень, сексуальність і, здається, що немає нічого красивішого. Цей танець розвиває гнучкість, пластику, витривалість, а також формує красиву поставу і граційність. Видовищність, епатаж, манерність &ndash; головні складові Джаз-Фанку.</span></span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><br>
<br>
&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/contemporary-Dance.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;""><span style=""font-size:24px;""><span style=""color:#696969;""><u><strong>Contemporary dance</strong></u><strong>.</strong></span></span> </span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">Стиль сучасного сценічного танцю. Часто виконується босоніж. Особливий тим, що приділяє увагу внутрішнім відчуттям танцівника, змісту самого руху, його взаємодії з простором, партнером, часом. У сучасному світі contemporary dance займаються не лише професійні танцівники, але й люди, які не мали раніше до танців&nbsp;жодного стосунку.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;&nbsp;<img alt="""" src=""/7c4be12e95c2fc51ce672833a6ad4f07.jpeg"" style=""width: 153px; height: 118px;"">&nbsp;&nbsp; &nbsp;&nbsp;<span style=""color:#FF8C00;""><u><strong><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;"">Східні танці.</span></span></strong></u></span> <span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">Наразі найпопулярніший стиль танцю серед жінок абсолютно різної комплекції. Ми пропонуємо унікальний сид танців - східні танці з</span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">фітнеспрограмою!&nbsp;Розвиває силу, гнучкість, самоконтроль, жіночнісь. Ніжні мелодії та пластичні рухи домоможуть вам справитись </span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">з дипресією та набути впевненості у собі.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/pilates5.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><span style=""font-family:comic sans ms,cursive;""><span style=""color:#000000;""><span style=""font-size:24px;""><u><strong>Пілатес</strong></u><strong>.</strong></span></span></span><span style=""font-size:14px;""> </span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">Розвиває координацію, покращує гнучкість, вчить рухатися красиво і граційно. Заняття пілатесом корисні людям будь-якого віку і статі, всім, хто хоче добре виглядати і бути у відмінній формі. Він є одним з найбезпечніших видів тренування, що має м'яку дію на тіло, одночасно зміцнюючи його.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><br>
<br>
<br>
<br>
<br>
&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/strip_2.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#808080;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><u><strong>Strip-dance</strong></u><strong>.</strong></span></span></span><span style=""font-size:16px;""><span style=""color:#000000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""line-height: 17.6000003814697px;"">Один</span>&nbsp;з наймодніших напрямків у клубних танцях. Завдяки йому можна не тільки набути і зберегти форму, але й відкрити в собі нові можливості , стати&nbsp;впевненішими. Ви створюєте себе самі! Адже одне з завдань уроку&nbsp;не тільки звикнути до свого тіла, але й полюбити себе.</span></span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><span style=""color:#696969;""><strong><u><span style=""font-size:16px;"">Чекаємо на вас за попереднім записом у адміністратора!</span></u></strong></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>
</div>"

			});

			#endregion

			#region Фитнес

			adultService.Courses.Add(new Course
			{
				Name = "Фітнес",
				Description = "Фітнес",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 3,
				BodyHtml = @"<div class=""eText"" colspan=""2""><div id=""nativeroll_video_cont"" style=""display:none;""></div><p><span style=""font-size:14pt;"">Сочетание динамической аэробики с силовым комплексом, направленным на коррекцию проблемных зон. Тренировка состоит из разминки высокой интенсивности + силовые упражнения с использованием фитболов, гантель, гимнастических мячей и т.д. и растяжки.</span></p>

<p><br>
<span style=""font-size:14pt;"">Каждое занятие направленное на коррекцию отдельных зон.&nbsp;</span></p>

<p>&nbsp;</p>

<p><span style=""font-size:14pt;"">Занятия проходят вт, чт в 19.00, 20.00.</span></p>

<p><br>
<span style=""font-size:14pt;"">*Если есть проблемы со здоровьем (грыжи, варикоз и тд) или беременность, кормление грудью, необходимо предупредить администратора и тренера перед началом занятий. К таким клиентам предусмотрен индивидуальный подход и более щадящая тренировка.</span></p></div>"
			});

			#endregion

			context.Services.AddOrUpdate(s => s.Name, adultService);
			context.SaveChanges();

			#endregion

			#endregion

			#region HtmlContent

			#region About page

			context.HtmlContents.AddOrUpdate(c => c.Name,
				new HtmlContent
				{
					CreationDate = DateTime.Now,
					Name = "About",
					BodyHtml = @"<br />
	<br />
	<div class=""row"">
		<div class=""col-md-2 col-md-offset-2"">
			<img src=""~/Content/img/logo 500x422.png"" class=""img-responsive"" />
		</div>
		<div class=""col-md-6"">
			Гоночная аркада DiRT Showdown была выпущена компанией Codemasters в 2012 году.
			Главными особенностями игры являются уровни «Разрушительного Дерби», знакомые игрокам по серии Flatout от студии Bugbear.
			Также в игре представлены арены со свободными трюками, мультиплеер на 8 игроков,
			а также режим разделенного экрана Split Screen, позволяющий сыграть вдвоем на одном компьютере.
		</div>
	</div>
	<br />
	<br />
	<h3 class=""text-center""><strong>Наши достижения</strong></h3>
	<br />
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">39</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Работников</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">230</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Клиентов за год</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">435</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Дошкольников</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">125</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Школьников</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">38</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Взрослых</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">8</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Лет опыта</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">3</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Филии</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">67</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">Курсов</h4>
					Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus
				</div>
			</div>
		</div>
	</div>"
				});

			#endregion

			#region Features Main page part

			context.HtmlContents.AddOrUpdate(hc => hc.Name,
				new HtmlContent
				{
					CreationDate = DateTime.Now,
					Name = "FeatureBlock",
					BodyHtml = @"<div class=""row"">
			<div class=""col-md-6"">
				<img src=""../Content/img/features/зірка.svg"" />
				<h4>Ми допомагаємо дитині дорослішати, зберігаючи всі найкращі дитячі якості: відкритість, довіру, радісне сприйняття світу, інтерес до всього, що оточує.</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/розвиток.svg"" />
				<h4>Ми мотивуємо дітей до особистого росту та умінню працювати в команді</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/друзі.svg"" />
				<h4>Ми залишаємо безцінні спогади та об’єднуємо друзів на все життя</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/кульки.svg"" />
				<h4>Ми знаходимо особливий підхід до кожної дитини, допомагаємо дітям і дорослим краще розуміти один одного, наповнюємо життя сім’ї активним спілкуванням, радістю, творчістю, любов’ю.</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/стіна.svg"" />
				<h4>Ми цінуємо кожну хвилину дитинства і допомагаємо будувати надійний фундамент всього життя</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/двері.svg"" />
				<h4>Ми відкриті до нових пропозицій та ідей</h4>
			</div>
		</div>"
				});

			#endregion

			context.SaveChanges();

			#endregion
		}

		private string MapPath(string seedFile)
		{
			if (HttpContext.Current != null)
				return HostingEnvironment.MapPath(seedFile);

			var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
			var directoryName = Path.GetDirectoryName(absolutePath);
			var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

			return path;
		}
	}
}
