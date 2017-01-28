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

			#region Slider

			var slide1 = new Raiduga.Models.File
			{
				ContentType = "image/jpeg",
				FileName = "райдуга-слайд-1.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide1.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide1);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "Райдуга",
					SubTitle = "Центр інтелектуального та творчого розвитку особистості",
					ImageId = slide1.Id
				});

			var slide2 = new Raiduga.Models.File
			{
				ContentType = "image/jpeg",
				FileName = "райдуга-слайд-2.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide2.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide2);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "Щастя",
					SubTitle = "Ми знаємо як зробити ваших дітей щасливими",
					ImageId = slide2.Id
				});

			var slide3 = new Raiduga.Models.File
			{
				ContentType = "image/jpeg",
				FileName = "райдуга-слайд-3.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide3.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide3);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "Спогади та друзі",
					SubTitle = "Ми залишаємо безцінні спогади та об’єднуємо друзів на все життя",
					ImageId = slide3.Id
				});

			#endregion

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

			#region Інтенсивний курс підготовки до школи

			preSchollService.Courses.Add(new Course
			{
				Name = "Інтенсивний курс підготовки до школи",
				Description = @"Перехід з садочка до школи може виявитись тяжким випробуванням для дитини.
Ми створимо сприятливі умови для того, щоб Ваш майбутній школяр здобув віру в себе, в свої сили та здібності.
І почував себе дорослою людиною, гордо називаючись школярем.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 90, 0),
				Price = "120 грн",
				PriorityOrder = 1,
				BodyHtml = @"
Перехід з садочка до школи може виявитись тяжким випробуванням для дитини.
Ми створимо сприятливі умови для того, щоб Ваш майбутній школяр здобув віру в себе, в свої сили та здібності.
І почував себе дорослою людиною, гордо називаючись школярем.
"
			});

			#endregion

			#region Сходинки до знань

			preSchollService.Courses.Add(new Course
			{
				Name = "Сходинки до знань",
				Description = "Запрошуємо на веселі та захоплюючі заняття з розвитку. Ми навчимо Ваших діточок читати, правильно і гарно писати, рахувати, вільно спілкуватися і комфортно почуватись себе в колективі, працювати в команді.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				Price = "80 грн",
				PriorityOrder = 1,
				BodyHtml = @"Запрошуємо на веселі та захоплюючі заняття з розвитку. Ми навчимо Ваших діточок читати, правильно і гарно писати, рахувати, вільно спілкуватися і комфортно почуватись себе в колективі, працювати в команді."
			});

			#endregion

			#region Навчаємось з мамою
			preSchollService.Courses.Add(new Course
			{
				Name = "Навчаємось з мамою",
				Description = @"Кожен день Вашого малюка - це крок у доросле життя.
Разом ми спонукаємо його долучитися до світу Знань та Умінь, пізнати Себе й  Інших, навчимо справлятися зі своїми Хочу і Боюсь.
А головне - ми зробимо дитину щасливішою від власного усвідомлення Я МОЖУ, Я САМ, Я РОСТУ !!!
Наші психологи допоможуть мамам навчитися дозволяти дитині ставати самостійнішою, справлятися з капризами, допоможуть розвинути її найкращі якості, навчити вчитися.
Ми допоможемо скласти карту розвитку Вашої дитини та впоратися з труднощами.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 50, 0),
				Price = "80 грн",
				PriorityOrder = 1,
				BodyHtml = @"Кожен день Вашого малюка - це крок у доросле життя.
Разом ми спонукаємо його долучитися до світу Знань та Умінь, пізнати Себе й  Інших, навчимо справлятися зі своїми Хочу і Боюсь.
А головне - ми зробимо дитину щасливішою від власного усвідомлення Я МОЖУ, Я САМ, Я РОСТУ !!!
Наші психологи допоможуть мамам навчитися дозволяти дитині ставати самостійнішою, справлятися з капризами, допоможуть розвинути її найкращі якості, навчити вчитися.
Ми допоможемо скласти карту розвитку Вашої дитини та впоратися з труднощами."
			});

			#endregion

			#region Англійська мова (групова)
			preSchollService.Courses.Add(new Course
			{
				Name = "Англійська мова (групова)",
				Description = @"Завдяки комфортній психологічній обстановці, умінням та знанням педагога, а також захоплюючому процесу гри, заняття з англійської мови викликають в дошкільнят інтерес до навчання то в загальному до іноземної мови.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 50, 0),
				Price = "50 грн",
				PriorityOrder = 1,
				BodyHtml = @"Завдяки комфортній психологічній обстановці, умінням та знанням педагога, а також захоплюючому процесу гри, заняття з англійської мови викликають в дошкільнят інтерес до навчання то в загальному до іноземної мови."
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
				Name = "Англійська мова",
				Description = "Англійська мова",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "100 грн",
				BodyHtml = @""
			});

			#region Логопед (індивідуальні заняття)
			schollService.Courses.Add(new Course
			{
				Name = "Логопед (індивідуальні заняття)",
				Description = @"
Говорити гарно та впевнено, використовуючи багатий словниковий запас – тобто так, що інші заслуховувались – Вашу дитину навчить професійний логопед. Після занять з нашим спеціалістом, розговориться навіть найсором`язливіший мовчун.
",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"
Говорити гарно та впевнено, використовуючи багатий словниковий запас – тобто так, що інші заслуховувались – Вашу дитину навчить професійний логопед. Після занять з нашим спеціалістом, розговориться навіть найсором`язливіший мовчун.
"
			});

			#endregion

			#region Психолог
			schollService.Courses.Add(new Course
			{
				Name = "Психолог (консультація)",
				Description = @"Хто як не люблячі батьки помічає найменші зміни в настрої своєї дитини і тут же кидається їй допомогти? І часто досить однієї любові, ласки і терпіння, щоб допомогти малюкові, але в житті бувають такі ситуації, коли однією батьківською любов’ю не обійтися. Якщо у Вас виникають питання, проблеми з якими не можете справитись самостійно ми прийдемо Вам на допомогу. Наш психолог допоможе справитись з будь якою ситуацією.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"Хто як не люблячі батьки помічає найменші зміни в настрої своєї дитини і тут же кидається їй допомогти? І часто досить однієї любові, ласки і терпіння, щоб допомогти малюкові, але в житті бувають такі ситуації, коли однією батьківською любов’ю не обійтися. Якщо у Вас виникають питання, проблеми з якими не можете справитись самостійно ми прийдемо Вам на допомогу. Наш психолог допоможе справитись з будь якою ситуацією."
			});

			#endregion

			#region Психолог
			schollService.Courses.Add(new Course
			{
				Name = "Театральна студія",
				Description = @"В кожній маленькій дитині живе великий актор. Його просто потрібно знайти та розворушити! На заняття театральної студії діти не тільки оволодівають акторською майстерністю, але і розвивають фантазію, уяву, стають товариськими і впевненими в собі.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"В кожній маленькій дитині живе великий актор. Його просто потрібно знайти та розворушити! На заняття театральної студії діти не тільки оволодівають акторською майстерністю, але і розвивають фантазію, уяву, стають товариськими і впевненими в собі."
			});

			#endregion

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
				Name = "Східні танці",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(1, 15, 0),
				Price = "100",
				PriorityOrder = 1,
				Description = "Рухи східного танцю, які прийшли із самої природи це, в першу чергу, гнучкість,гарна пластика та гарна координація. Люди, маючи ці якості, завжди привертають до себе увагу. Привертають погляд хвилеподібні рухи рук, легкість в ногах, внутрішній вогонь, свобода і впевненість в своєму шармі. Танець стає дзеркалом, в якому можна по іншому побачити свої проблеми і зробити крок до їхнього подолання.",
				BodyHtml = @"<p></p>"
			});

			#region Cучасні танці

			adultService.Courses.Add(new Course
			{
				Name = "Сучасні танці",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(1, 30, 0),
				Description = " Сучасні танці – це сукупність різних найпопулярніших та найновіших стилів хореографії, ними можуть займатись як діти так і дорослі. В кожного століття були свої сучасні танці, в 21 столітті до сучасних танців відносяться : контемп, модерн, джаз, джаз – фанк, хіп – хоп, брейкданс , і багато інших. Заняття сучасними танцями корисно для дітей тим, що , покращує координацію рухів, пам’ять і мислення, розвиток емоційного стану, вирівнює поставу та тонус тіла, виробляє пластику та гнучкість, розтяжку, музичний слух та ритміку.",
				Price = "100",
				PriorityOrder = 2,
				BodyHtml = @""
			});

			#endregion

			#region Фитнес

			adultService.Courses.Add(new Course
			{
				Name = "Фітнес",
				Description = "Осінь - саме час зайнятися собою і нарешті зробити вже те, що збиралися зробити кожен понеділок з тих пір, як закінчилися новорічні свята . Записатися у фітнес-клуб! Як раз ще є час, щоб привести себе у форму до чергового виходу у світ, будь то новорічний корпоратив або дружня вечірка.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 45, 0),
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
					BodyHtml = @"<div class=""row about"">
	<div class=""col-md-2 col-md-offset-2"">
		<img src=""/Content/img/logo/логотип-центр-райдуга.png"" class=""img-responsive"" />
	</div>
	<div class=""col-md-6"">
		Ідея створення Центру розвитку  виникла у мене після свідомого народження третьої дитини. Мені конче потрібно було поділитися з іншими батьками своїми уміннями,спостереженнями, досягненнями, навичками,успіхами. Було бажання дати   якомога більше дітям можливість отримати гідну гарну освіту та знайти своє місце в житті. Я прагнула створити таке «райське» середовище для дітей та дорослих, де будь-кому можна було б поспілкуватись стосовно виховання чи навчання своєї дитини, отримати пораду та підтримку, розвинути свої таланти.
		Безумовно поруч  з’явилися однодумці і тепер – це  наш міцний творчий педагогічний колектив, де кожен викладач віддано відноситься до своєї справи, цінує кожну мить швидкоплинного дитинства і віддає часточку свого серця кожній дитині.
	</div>
</div>

<div class=""row"">
	<br />
	<br />
	<h2 class=""text-center""><strong>Наші досягнення</strong></h2>
	<div class=""achievements"">
		<div class=""row achievement"">
			<div class=""number col-md-1 col-md-offset-3 col-sm-3 col-xs-4"">
				<div class=""media-object"">18</div>
			</div>
			<div class=""description col-md-5 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Працівників</h4>
				<p>У нас працюють висококваліфіковані викладачі з вищою освітою, які закохані у свою справу</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Філій</h4>
				<p>
					Філії на вул. Волгоградській, вул.Пітерській та вул. Донця, а ще наші викладачі надають
					додаткові освітні послуги у дитячих садочках №17 та №374 Солом’янського району міста Києва
				</p>
			</div>
			<div class=""number col-md-1 col-md-offset-0 col-sm-3 col-xs-4"">
				<div class=""media-object"">5</div>
			</div>
		</div>

		<div class=""row achievement"">
			<div class=""number col-md-1 col-md-offset-3 col-sm-3 col-xs-4"">
				<div class=""media-object"">7</div>
			</div>
			<div class=""description col-md-5 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Років досвіду</h4>
				<p>
					Робота за передовими сучасними та авторськими методиками навчання,
					індивідуальний підхід до розвитку та потреб кожного клієнта
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Клієнтів за рік</h4>
				<p>
					Саме стільки людей за минулий рік довірили нам своїх дітей, співпрацювали з нами, отримали результати та продовжили
					навчання далі на новому рівні
				</p>
			</div>
			<div class=""number col-md-1 col-md-offset-0 col-sm-3 col-xs-4"">
				<div class=""media-object"">310</div>
			</div>
		</div>

		<div class=""row achievement"">
			<div class=""number col-md-1 col-md-offset-3 col-sm-3 col-xs-4"">
				<div class=""media-object"">219</div>
			</div>
			<div class=""description col-md-5 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Дошкільнят</h4>
				<p>
					Щороку близько двохсот дошкільнят відвідують розвиваючі заняття,
					вчаться малювати, співати, творити, грають у різні
					ігри, святкують дні народження, просто живуть щасливо разом з нами
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Школярів</h4>
				<p>
					Продовжили навчання за напрямками «Англійська мова», «Хореографія», «Вокал», підтягнули
					деякі предмети, були з нами під час усіх канікул, стали дорослішими, впевненими в собі, знайшли
					улюблену справу та не зупинились на досягнутому
				</p>
			</div>
			<div class=""number col-md-1 col-md-offset-0 col-sm-3 col-xs-4"">
				<div class=""media-object"">37</div>
			</div>
		</div>

		<div class=""row achievement"">
			<div class=""number col-md-1 col-md-offset-3 col-sm-3 col-xs-4"">
				<div class=""media-object"">54</div>
			</div>
			<div class=""description col-md-5 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Дорослих</h4>
				<p>
					Отримали консультації, відвідали майстер-класи, тренінги, розібралися в собі, поставили цілі
					та досягли результатів
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Курсів</h4>
				<p>
					Курси охоплюють творчу та інтелектуальну сферу розвитку особистості, починаючи  від народження та закінчуючи …,
					не закінчуються ніколи для тих, хто не зупиняється на досягненому
				</p>
			</div>
			<div class=""number col-md-1 col-md-offset-0 col-sm-3 col-xs-4"">
				<div class=""media-object"">30</div>
			</div>
		</div>
	</div>
	<br />
	<br />
	<br />
	<br />
</div>

<div class=""row staff"">
	<h2 class=""text-center""><strong>Наш колектив</strong></h2>
	<div class=""staff-wrapper"">
		<div class=""row"">
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/1.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>Раковська Ірина Едуардівна</h3>
				<h4>директор, психолог</h4>
				<h5>НПУ ім. Драгоманова</h5>
				<p>
					Любов до справи щиру має, <br />
					І душу всю у Центр вкладає. <br />
					Світ радості, добра і миру <br />
					Вона у «Райдузі» створила. <br />
					Найбільша цінність – наші діти, <br />
					Їх успіхам будем радіти!
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/2.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>Калайда Юлія Миколаївна</h3>
				<h4>викладач-методист</h4>
				<h5>НПУ ім. М. Драгоманова</h5>
				<p>
					Мабуть немає в світі справи, <br />
					Яка була б не до снаги <br />
					І в психології цікавій, <br />
					І в творчості – шлях до мети!
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/3.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>Кременюк Аліна Олександрівна</h3>
				<h4>вихователь, логопед, підготовка до школи</h4>
				<h5>Уманський педагогічний інститут</h5>
				<p>
					Чудову мову гарно знає, <br />
					Логопедію викладає <br />
					Підхід до кожного знайде <br />
					В країну знань всіх проведе.
				</p>
			</div>
		</div>
		<div class=""row"">
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/default-user.png"" class=""img-circle img-responsive"" />
				</div>
				<h3>Федорчук Вікторія Миколаївна</h3>
				<h4>ранній розвиток, підготовка до школи</h4>
				<h5>НПУ ім. М.Драгоманова</h5>
				<p>
					Привітність, чіткість, компетентність <br />
					Та доброзичливість завжди <br />
					А ще чутливість, динамічність, <br />
					Й подяки щирі за труди.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div><img src=""/Content/img/staff/5.jpg"" class=""img-circle img-responsive"" /></div>
				<h3>Чуєнко Катерина Володимирівна</h3>
				<h4>викладач англійської мови, логіки</h4>
				<h5>НПУ ім. Драгоманова</h5>
				<p>
					Наполеглива в роботі <br />
					Чутлива  до чужих проблем <br />
					А Творчий рух – завжди в польоті, <br />
					Працює з радістю  без схем.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div><img src=""/Content/img/staff/6.jpg"" class=""img-circle img-responsive"" /></div>
				<h3>Бабенюк Марина Олегівна</h3>
				<h4>викладач вокалу</h4>
				<h5>Академія керівних кадрів культури</h5>
				<p>
					Ноти, ритми – не проблема, <br />
					Інструментом голос став. <br />
					Для дітей завжди приємна. <br />
					В співі – безліч гарних вправ!
				</p>
			</div>
		</div>
		<div class=""row"">
			<div class=""col-md-4 col-md-offset-2 person"">
				<div>
					<img src=""/Content/img/default-user.png"" class=""img-circle img-responsive"" />
				</div>
				<h3>Яцун Оксана Сергіївна</h3>
				<h4>викладач математики, логіки, інформатики</h4>
				<h5>НПУ ім. М. Драгоманова</h5>
				<p>
					Педагогічний шлях обрала, <br />
					Бажання щире є навчать, <br />
					І часом разом малишнею <br />
					Задачі з логіки складать.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/8.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>Оганесян Яна Анатоліївна</h3>
				<h4>адміністратор</h4>
				<h5>Державний університет телекомунікацій</h5>
				<p>
					Уважна, чуйна та привітна <br />
					Усім на поміч радо йде, <br />
					Турбот немає другорядних - <br />
					Порядок в офісі веде.
				</p>
			</div>
		</div>
	</div>
</div>
"
                });

			#endregion

			#region Features Main page part

			context.HtmlContents.AddOrUpdate(hc => hc.Name,
				new HtmlContent
				{
					CreationDate = DateTime.Now,
					Name = "FeatureBlock",
					BodyHtml = @"
<div class=""features"">
                        <div class=""row features"">
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/зірка.svg"" /></div>
                        <div>
                        <p>Ми допомагаємо дитині дорослішати, зберігаючи всі найкращі дитячі якості: відкритість, довіру, радісне сприйняття світу, інтерес до всього, що оточує.</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/розвиток.svg"" /></div>
                        <div>
                        <p>Ми мотивуємо дітей до особистого росту та умінню працювати в команді</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/друзі.svg"" /></div>
                        <div>
                        <p>Ми залишаємо безцінні спогади та об&rsquo;єднуємо друзів на все життя</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/кульки.svg"" /></div>
                        <div>
                        <p>Ми знаходимо особливий підхід до кожної дитини, допомагаємо дітям і дорослим краще розуміти один одного, наповнюємо життя сім&rsquo;ї активним спілкуванням, радістю, творчістю, любов&rsquo;ю.</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/стіна.svg"" /></div>
                        <div>
                        <p>Ми цінуємо кожну хвилину дитинства і допомагаємо будувати надійний фундамент всього життя</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/двері.svg"" /></div>
                        <div>
                        <p>Ми відкриті до нових пропозицій та ідей</p>
                        </div>
                        </div>
                        </div>
</div>
                    "
				});

			#endregion

			context.SaveChanges();

			#endregion

			#region Feedbacks

			context.UserFeedbacks.AddOrUpdate(f => f.UserName,
				new UserFeedback
				{
					CreationDate = DateTime.Now,
					IsActive = true,
					UserName = "Светлана Бараник",

					Text = @"Мы пришли в «Райдугу» , когда Дочке исполнилось 1,5 года. Начав с курса «Учимся с мамой»,
прошли за 5 лет все ступеньки обучения, теперь успешно учимся в школе, но с Центром не расстаемся. Приходим пообщаться, по вечерам, на каникулах, с удовольствием продолжаем заниматься английским, посещаем мастер-классы, праздники. В Райдуге работают замечательные педагоги и воспитатели, спасибо им за все!"
				});

			context.UserFeedbacks.AddOrUpdate(f => f.UserName,
				new UserFeedback
				{
					CreationDate = DateTime.Now,
					IsActive = true,
					UserName = "Гаяне Трегуб",

					Text = @"В Центр мы попали по рекомендации наших знакомых, привели старшую дочь на развивающие занятия в 2 года и остались до самой школы. Теперь в «Райдугу» ходит средний сын, а младшенький пока там привыкает в игровой. Я спокойна, когда мои дети в Центре, а это главное, для каждой мамы."
				});

			context.UserFeedbacks.AddOrUpdate(f => f.UserName,
				new UserFeedback
				{
					CreationDate = DateTime.Now,
					IsActive = true,
					UserName = "Баглай  Оксана",

					Text = @"Хочу поблагодарить коллектив Центра «Райдуга» за их творческую работу, их любовь к детям, понимание родителей. Педагоги действительно вкладывают в детей всю душу, находят подход к каждому ребенку, развивают его сильные стороны. До сих пор в памяти замечательные праздники, концерты! Желаю замечательному коллективу успехов и процветания!"
				});

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
