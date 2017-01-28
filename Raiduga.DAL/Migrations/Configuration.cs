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
				FileName = "�������-�����-1.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide1.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide1);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "�������",
					SubTitle = "����� ���������������� �� �������� �������� ����������",
					ImageId = slide1.Id
				});

			var slide2 = new Raiduga.Models.File
			{
				ContentType = "image/jpeg",
				FileName = "�������-�����-2.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide2.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide2);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "�����",
					SubTitle = "�� ����� �� ������� ����� ���� ���������",
					ImageId = slide2.Id
				});

			var slide3 = new Raiduga.Models.File
			{
				ContentType = "image/jpeg",
				FileName = "�������-�����-3.jpg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/slide3.jpg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, slide3);
			context.SaveChanges();

			context.SliderItems.AddOrUpdate(s => s.Title,
				new SliderItem
				{
					Title = "������� �� ����",
					SubTitle = "�� �������� ������� ������� �� �ᒺ����� ����� �� ��� �����",
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
				Title = "���� 1",
				Description = "������� �i��i�����",
				Address = new Address
				{
					Name = "���. �������������, 18",
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
				Title = "���� 2",
				Description = "������� �����, ���� ����� �������� � ���.���������� �� ��������� �������",
				Address = new Address
				{
					Name = "���. ϳ�������, 4�",
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
				Title = "���� 3",
				Description = "� ������� ���������� ���, 2� ������",
				Address = new Address
				{
					Name = "���. ������� �����, 21�",
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

			#region �����������

			#region preSchollService
			var image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "�����������.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/�����������.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();

			var preSchollService = new Service
			{
				Name = "�����������",
				Description = @"����� �������� - �� ������� ������, � ����� ��������� ���������� �������� ���� ��
������� �� ��������� ����� � ���� ������������ ����.�� ��������� ������ � 1,5 ���� �� ������������ �� ���������� �������� �� �����. 
������ ������ ������ �� ������� �������� ��� ������, ��� � ������� ��������. ��
����� ������ � ������������� �����, ���������� ������������� ���� ��������. 
� 2,5 ���� ����� ��������� �������������� ��-���, � ���� ��������� - ����� �������
���.
�� �������� ����� �� ���������� �� ��������� �������� �����. ������� ������ ������� �������-����� �� ������, ������������, ���������� ����
��������� ����������� ������� � ��������� �� ������������ ���������.",
				ImageId = image.Id
			};
			#endregion

			#region Courses
			preSchollService.Courses = new List<Course>();

			#region ����������� ���� ��������� �� �����

			preSchollService.Courses.Add(new Course
			{
				Name = "����������� ���� ��������� �� �����",
				Description = @"������� � ������� �� ����� ���� ��������� ������ ������������� ��� ������.
�� �������� ��������� ����� ��� ����, ��� ��� �������� ������ ������ ��� � ����, � ��� ���� �� �������.
� ������� ���� �������� �������, ����� ����������� ��������.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 90, 0),
				Price = "120 ���",
				PriorityOrder = 1,
				BodyHtml = @"
������� � ������� �� ����� ���� ��������� ������ ������������� ��� ������.
�� �������� ��������� ����� ��� ����, ��� ��� �������� ������ ������ ��� � ����, � ��� ���� �� �������.
� ������� ���� �������� �������, ����� ����������� ��������.
"
			});

			#endregion

			#region �������� �� �����

			preSchollService.Courses.Add(new Course
			{
				Name = "�������� �� �����",
				Description = "��������� �� ����� �� ���������� ������� � ��������. �� ������� ����� ������ ������, ��������� � ����� ������, ��������, ����� ����������� � ��������� ���������� ���� � ��������, ��������� � ������.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				Price = "80 ���",
				PriorityOrder = 1,
				BodyHtml = @"��������� �� ����� �� ���������� ������� � ��������. �� ������� ����� ������ ������, ��������� � ����� ������, ��������, ����� ����������� � ��������� ���������� ���� � ��������, ��������� � ������."
			});

			#endregion

			#region ��������� � �����
			preSchollService.Courses.Add(new Course
			{
				Name = "��������� � �����",
				Description = @"����� ���� ������ ������ - �� ���� � ������� �����.
����� �� ��������� ���� ���������� �� ���� ����� �� ����, ������ ���� �  �����, ������� ����������� � ����� ���� � �����.
� ������� - �� ������� ������ ��������� �� �������� ����������� � ����, � ���, � ����� !!!
���� ��������� ���������� ����� ��������� ��������� ����� ������� �����������, ����������� � ���������, ���������� ��������� �� �������� �����, ������� �������.
�� ���������� ������� ����� �������� ���� ������ �� ��������� � ����������.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 50, 0),
				Price = "80 ���",
				PriorityOrder = 1,
				BodyHtml = @"����� ���� ������ ������ - �� ���� � ������� �����.
����� �� ��������� ���� ���������� �� ���� ����� �� ����, ������ ���� �  �����, ������� ����������� � ����� ���� � �����.
� ������� - �� ������� ������ ��������� �� �������� ����������� � ����, � ���, � ����� !!!
���� ��������� ���������� ����� ��������� ��������� ����� ������� �����������, ����������� � ���������, ���������� ��������� �� �������� �����, ������� �������.
�� ���������� ������� ����� �������� ���� ������ �� ��������� � ����������."
			});

			#endregion

			#region ��������� ���� (�������)
			preSchollService.Courses.Add(new Course
			{
				Name = "��������� ���� (�������)",
				Description = @"������� ��������� ����������� ����������, ������ �� ������� ��������, � ����� ������������ ������� ���, ������� � ��������� ���� ���������� � ��������� ������� �� �������� �� � ���������� �� �������� ����.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 50, 0),
				Price = "50 ���",
				PriorityOrder = 1,
				BodyHtml = @"������� ��������� ����������� ����������, ������ �� ������� ��������, � ����� ������������ ������� ���, ������� � ��������� ���� ���������� � ��������� ������� �� �������� �� � ���������� �� �������� ����."
			});

			#endregion

			context.Services.AddOrUpdate(s => s.Name, preSchollService);
			context.SaveChanges();

			#endregion
			#endregion

			#region ����������
			image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "��������.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/��������.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();

			var schollService = new Service
			{
				Name = "��������",
				Description = @"��� ���� ����� � �� ��������� ������ ��� ����������, ��������� ���, ������ �����
�����, ����� ���������� � ���. � ��� ������ �nglish club, ����� ����������� �� ������ , ������� ��������� �� �������, 
������� �� ��� �� ���, ����� ����� �� ���������, ��������, ������������ � 
������, ����������� ��������� ����, �����, �������� �� ������� � �����. 
���������� ������� ����������� ��������� ������, �������� ����, 
������������ � ������� ������� �� ������� � ���������� �� ���������.",
				BodyHtml = "",
				ImageId = image.Id
			};

			#region Courses

			schollService.Courses = new List<Course>();
			schollService.Courses.Add(new Course
			{
				Name = "��������� ����",
				Description = "��������� ����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "100 ���",
				BodyHtml = @""
			});

			#region ������� (����������� �������)
			schollService.Courses.Add(new Course
			{
				Name = "������� (����������� �������)",
				Description = @"
�������� ����� �� ��������, �������������� ������� ����������� ����� � ����� ���, �� ���� ��������������� � ���� ������ ������� ���������� �������. ϳ��� ������ � ����� �����������, ������������� ����� ��������`�������� ������.
",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"
�������� ����� �� ��������, �������������� ������� ����������� ����� � ����� ���, �� ���� ��������������� � ���� ������ ������� ���������� �������. ϳ��� ������ � ����� �����������, ������������� ����� ��������`�������� ������.
"
			});

			#endregion

			#region ��������
			schollService.Courses.Add(new Course
			{
				Name = "�������� (������������)",
				Description = @"��� �� �� ������� ������ ����� �������� ���� � ������ �� ������ � ��� �� �������� �� ���������? � ����� ������ ���� �����, ����� � �������, ��� ��������� �������, ��� � ���� ������� ��� ��������, ���� ���� ����������� ������ �� �������. ���� � ��� ��������� �������, �������� � ����� �� ������ ���������� ��������� �� �������� ��� �� ��������. ��� �������� �������� ���������� � ���� ���� ���������.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"��� �� �� ������� ������ ����� �������� ���� � ������ �� ������ � ��� �� �������� �� ���������? � ����� ������ ���� �����, ����� � �������, ��� ��������� �������, ��� � ���� ������� ��� ��������, ���� ���� ����������� ������ �� �������. ���� � ��� ��������� �������, �������� � ����� �� ������ ���������� ��������� �� �������� ��� �� ��������. ��� �������� �������� ���������� � ���� ���� ���������."
			});

			#endregion

			#region ��������
			schollService.Courses.Add(new Course
			{
				Name = "���������� �����",
				Description = @"� ����� �������� ����� ���� ������� �����. ���� ������ ������� ������ �� �����������! �� ������� ���������� ���䳿 ��� �� ����� ����������� ���������� �����������, ��� � ���������� �������, ����, ������ ������������ � ���������� � ���.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 60, 0),
				PriorityOrder = 1,
				Price = "150",
				BodyHtml = @"� ����� �������� ����� ���� ������� �����. ���� ������ ������� ������ �� �����������! �� ������� ���������� ���䳿 ��� �� ����� ����������� ���������� �����������, ��� � ���������� �������, ����, ������ ������������ � ���������� � ���."
			});

			#endregion

			#endregion

			context.Services.AddOrUpdate(s => s.Name, schollService);
			context.SaveChanges();

			#endregion

			#region ��������
			image = new Raiduga.Models.File
			{
				ContentType = "image/svg+xml",
				FileName = "��������.svg",
				Content = System.IO.File.ReadAllBytes(MapPath("~/../../Raiduga.Web/Content/img/services/��������.svg"))
			};
			context.Files.AddOrUpdate(img => img.FileName, image);
			context.SaveChanges();
			var adultService = new Service
			{
				Name = "��������",
				Description = @"�������� ���������� �� ����������� ���������� �������� ������. �� ������� ���� 
����� �� ��������� � ����������, �������, ��������, ���������. �����, ���� �� ����� 
������������ �, ��� �������, �������� ����������, ��������. ��� �������� �������� 
������� � ��� �������� ����� ��������� �� ��������� ����, ������������ ����������� 
��������������. �� �� �������� � ��� ������� �� �������� ��������, ���� ��� ��� 
������ ���������, ���� � ��� ����� � ��������, � �����������, � ��� ����� �� 
�������� ���� ������ �� ��������� ������ �� ����������� ������ ���� � �������� 
�� ��������.",
				BodyHtml = "",
				Courses = new List<Course>(),
				ImageId = image.Id
			};

			adultService.Courses.Add(new Course
			{
				Name = "����� �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(1, 15, 0),
				Price = "100",
				PriorityOrder = 1,
				Description = "���� �������� �����, �� ������� �� ���� ������� ��, � ����� �����, ��������,����� �������� �� ����� �����������. ����, ����� �� �����, ������ ����������� �� ���� �����. ����������� ������ ���������� ���� ���, ������� � �����, �������� ������, ������� � ���������� � ����� ����. ������ ��� ���������, � ����� ����� �� ������ �������� ��� �������� � ������� ���� �� ������� ���������.",
				BodyHtml = @"<p></p>"
			});

			#region C����� �����

			adultService.Courses.Add(new Course
			{
				Name = "������ �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(1, 30, 0),
				Description = " ������ ����� � �� ��������� ����� �������������� �� ��������� ����� �����������, ���� ������ ��������� �� ��� ��� � ������. � ������� ������� ���� ��� ������ �����, � 21 ������ �� �������� ������ ���������� : �������, ������, ����, ���� � ����, ��� � ���, ��������� , � ������ �����. ������� ��������� ������� ������� ��� ���� ���, �� , ������� ����������� �����, ������ � ��������, �������� ���������� �����, ������� ������� �� ����� ���, �������� �������� �� ��������, ��������, �������� ���� �� ������.",
				Price = "100",
				PriorityOrder = 2,
				BodyHtml = @""
			});

			#endregion

			#region ������

			adultService.Courses.Add(new Course
			{
				Name = "Գ����",
				Description = "���� - ���� ��� ��������� ����� � ������ ������� ��� ��, �� ��������� ������� ����� �������� � ��� ��, �� ���������� ������� ����� . ���������� � ������-����! �� ��� �� � ���, ��� �������� ���� � ����� �� ��������� ������ � ���, ���� �� ��������� ���������� ��� ������ �������.",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0, 45, 0),
				Price = "100",
				PriorityOrder = 3,
				BodyHtml = @"<div class=""eText"" colspan=""2""><div id=""nativeroll_video_cont"" style=""display:none;""></div><p><span style=""font-size:14pt;"">��������� ������������ �������� � ������� ����������, ������������ �� ��������� ���������� ���. ���������� ������� �� �������� ������� ������������� + ������� ���������� � �������������� ��������, �������, �������������� ����� � �.�. � ��������.</span></p>

<p><br>
<span style=""font-size:14pt;"">������ ������� ������������ �� ��������� ��������� ���.&nbsp;</span></p>

<p>&nbsp;</p>

<p><span style=""font-size:14pt;"">������� �������� ��, �� � 19.00, 20.00.</span></p>

<p><br>
<span style=""font-size:14pt;"">*���� ���� �������� �� ��������� (�����, ������� � ��) ��� ������������, ��������� ������, ���������� ������������ �������������� � ������� ����� ������� �������. � ����� �������� ������������ �������������� ������ � ����� ������� ����������.</span></p></div>"
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
		<img src=""/Content/img/logo/�������-�����-�������.png"" class=""img-responsive"" />
	</div>
	<div class=""col-md-6"">
		���� ��������� ������ ��������  ������� � ���� ���� �������� ���������� ������ ������. ��� ����� ������� ���� ��������� � ������ �������� ����� �������,���������������, ������������, ���������,�������. ���� ������� ����   ������� ����� ���� ��������� �������� ���� ����� ����� �� ������ ��� ���� � ����. � �������� �������� ���� �������� ���������� ��� ���� �� ��������, �� ����-���� ����� ���� � ������������� �������� ��������� �� �������� �� ������, �������� ������ �� ��������, ��������� ��� �������.
		��������� �����  �������� ��������� � ����� � ��  ��� ����� ������� ����������� ��������, �� ����� �������� ������ ���������� �� �� ������, ���� ����� ���� �������������� ��������� � ���� �������� ����� ����� ����� �����.
	</div>
</div>

<div class=""row"">
	<br />
	<br />
	<h2 class=""text-center""><strong>���� ����������</strong></h2>
	<div class=""achievements"">
		<div class=""row achievement"">
			<div class=""number col-md-1 col-md-offset-3 col-sm-3 col-xs-4"">
				<div class=""media-object"">18</div>
			</div>
			<div class=""description col-md-5 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">����������</h4>
				<p>� ��� �������� ����������������� ��������� � ����� ������, �� ������� � ���� ������</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">Գ��</h4>
				<p>
					Գ볿 �� ���. �������������, ���.ϳ������� �� ���. �����, � �� ���� ��������� �������
					�������� ����� ������� � ������� �������� �17 �� �374 ������������� ������ ���� ����
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
				<h4 class=""media-heading"">���� ������</h4>
				<p>
					������ �� ���������� ��������� �� ����������� ���������� ��������,
					������������� ����� �� �������� �� ������ ������� �볺���
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">�볺��� �� ��</h4>
				<p>
					���� ������ ����� �� ������� �� ������� ��� ���� ����, ������������ � ����, �������� ���������� �� ����������
					�������� ��� �� ������ ���
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
				<h4 class=""media-heading"">���������</h4>
				<p>
					������ ������� ������� ��������� �������� ���������� �������,
					������� ��������, ������, �������, ������ � ���
					����, ��������� �� ����������, ������ ������ ������� ����� � ����
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">�������</h4>
				<p>
					���������� �������� �� ���������� ���������� ����, �������������, ������, ���������
					���� ��������, ���� � ���� �� ��� ��� ������, ����� ����������, ���������� � ���, �������
					�������� ������ �� �� ���������� �� �����������
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
				<h4 class=""media-heading"">��������</h4>
				<p>
					�������� ������������, ������� �������-�����, �������, ���������� � ���, ��������� ���
					�� ������� ����������
				</p>
			</div>
		</div>
		<div class=""row achievement"">
			<div class=""description col-md-5 col-md-offset-3 col-sm-9 col-xs-8"">
				<h4 class=""media-heading"">�����</h4>
				<p>
					����� ��������� ������ �� �������������� ����� �������� ����������, ���������  �� ���������� �� ��������� �,
					�� ����������� ����� ��� ���, ��� �� ����������� �� �����������
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
	<h2 class=""text-center""><strong>��� ��������</strong></h2>
	<div class=""staff-wrapper"">
		<div class=""row"">
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/1.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>��������� ����� ���������</h3>
				<h4>��������, ��������</h4>
				<h5>��� ��. �����������</h5>
				<p>
					����� �� ������ ���� ��, <br />
					� ���� ��� � ����� ������. <br />
					��� ������, ����� � ���� <br />
					���� � ������系 ��������. <br />
					�������� ������� � ���� ���, <br />
					�� ������ ����� �����!
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/2.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>������� ��� ���������</h3>
				<h4>��������-��������</h4>
				<h5>��� ��. �. �����������</h5>
				<p>
					������ ���� � ��� ������, <br />
					��� ���� � �� �� ����� <br />
					� � �������㳿 ������, <br />
					� � �������� � ���� �� ����!
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/3.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>�������� ���� ������������</h3>
				<h4>����������, �������, ��������� �� �����</h4>
				<h5>��������� ����������� ��������</h5>
				<p>
					������ ���� ����� ���, <br />
					�������� ������� <br />
					ϳ���� �� ������� ������ <br />
					� ����� ����� ��� �������.
				</p>
			</div>
		</div>
		<div class=""row"">
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/default-user.png"" class=""img-circle img-responsive"" />
				</div>
				<h3>�������� ³����� ���������</h3>
				<h4>����� ��������, ��������� �� �����</h4>
				<h5>��� ��. �.�����������</h5>
				<p>
					���������, �������, ������������� <br />
					�� �������������� ������ <br />
					� �� ���������, ����������, <br />
					� ������ ��� �� �����.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div><img src=""/Content/img/staff/5.jpg"" class=""img-circle img-responsive"" /></div>
				<h3>����� �������� ������������</h3>
				<h4>�������� ��������� ����, �����</h4>
				<h5>��� ��. �����������</h5>
				<p>
					����������� � ����� <br />
					�������  �� ����� ������� <br />
					� ������� ��� � ������ � ������, <br />
					������ � ������  ��� ����.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div><img src=""/Content/img/staff/6.jpg"" class=""img-circle img-responsive"" /></div>
				<h3>������� ������ �������</h3>
				<h4>�������� ������</h4>
				<h5>������� ������� ����� ��������</h5>
				<p>
					����, ����� � �� ��������, <br />
					������������ ����� ����. <br />
					��� ���� ������ ������. <br />
					� ��� � ����� ������ �����!
				</p>
			</div>
		</div>
		<div class=""row"">
			<div class=""col-md-4 col-md-offset-2 person"">
				<div>
					<img src=""/Content/img/default-user.png"" class=""img-circle img-responsive"" />
				</div>
				<h3>���� ������ ���㳿���</h3>
				<h4>�������� ����������, �����, �����������</h4>
				<h5>��� ��. �. �����������</h5>
				<p>
					����������� ���� ������, <br />
					������� ���� � �������, <br />
					� ����� ����� �������� <br />
					������ � ����� ��������.
				</p>
			</div>
			<div class=""col-md-4 person"">
				<div>
					<img src=""/Content/img/staff/8.jpg"" class=""img-circle img-responsive"" />
				</div>
				<h3>�������� ��� �����볿���</h3>
				<h4>�����������</h4>
				<h5>��������� ���������� ��������������</h5>
				<p>
					������, ����� �� ������� <br />
					��� �� ���� ���� ���, <br />
					������ ���� ����������� - <br />
					������� � ���� ����.
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
                        <div><img src=""../Content/img/features/����.svg"" /></div>
                        <div>
                        <p>�� ���������� ����� ����������, ��������� �� �������� ������ �����: ���������, �����, ������ ���������� ����, ������� �� ������, �� �����.</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/��������.svg"" /></div>
                        <div>
                        <p>�� �������� ���� �� ���������� ����� �� ����� ��������� � ������</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/����.svg"" /></div>
                        <div>
                        <p>�� �������� ������� ������� �� ��&rsquo;������ ����� �� ��� �����</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/������.svg"" /></div>
                        <div>
                        <p>�� ��������� ��������� ����� �� ����� ������, ���������� ���� � �������� ����� ������� ���� ������, ���������� ����� ��&rsquo;� �������� �����������, ������, ���������, �����&rsquo;�.</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/����.svg"" /></div>
                        <div>
                        <p>�� ������ ����� ������� ��������� � ���������� �������� ������� ��������� ������ �����</p>
                        </div>
                        </div>
                        <div class=""col-md-6"">
                        <div><img src=""../Content/img/features/����.svg"" /></div>
                        <div>
                        <p>�� ������ �� ����� ���������� �� ����</p>
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
					UserName = "�������� �������",

					Text = @"�� ������ � �������� , ����� ����� ����������� 1,5 ����. ����� � ����� ������� � �����,
������ �� 5 ��� ��� ��������� ��������, ������ ������� ������ � �����, �� � ������� �� ����������. �������� ����������, �� �������, �� ���������, � ������������� ���������� ���������� ����������, �������� ������-������, ���������. � ������� �������� ������������� �������� � �����������, ������� �� �� ���!"
				});

			context.UserFeedbacks.AddOrUpdate(f => f.UserName,
				new UserFeedback
				{
					CreationDate = DateTime.Now,
					IsActive = true,
					UserName = "����� ������",

					Text = @"� ����� �� ������ �� ������������ ����� ��������, ������� ������� ���� �� ����������� ������� � 2 ���� � �������� �� ����� �����. ������ � �������� ����� ������� ���, � ����������� ���� ��� ��������� � �������. � ��������, ����� ��� ���� � ������, � ��� �������, ��� ������ ����."
				});

			context.UserFeedbacks.AddOrUpdate(f => f.UserName,
				new UserFeedback
				{
					CreationDate = DateTime.Now,
					IsActive = true,
					UserName = "������  ������",

					Text = @"���� ������������� ��������� ������ �������� �� �� ���������� ������, �� ������ � �����, ��������� ���������. �������� ������������� ���������� � ����� ��� ����, ������� ������ � ������� �������, ��������� ��� ������� �������. �� ��� ��� � ������ ������������� ���������, ��������! ����� �������������� ���������� ������� � �����������!"
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
