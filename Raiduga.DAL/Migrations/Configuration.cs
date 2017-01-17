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

			#region ���������� � �����

			preSchollService.Courses.Add(new Course
			{
				Name = "���������� � �����",
				Description = "���������� � �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				BodyHtml = @"<div id=""they"">
<p id=""they_head"">&nbsp;</p>

<p style=""text-align: center;""><span style=""color:#A52A2A;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><strong>�������� ��������� �� ����� ""<u>�������� �� �����</u>""</strong></span></span></span></p>

<p style=""text-align: center;"">&nbsp;</p>

<p style=""text-align: center;""><img alt="""" src=""/images.jpg"" style=""width: 248px; height: 204px;""></p>

<ul>
 <li>
 <p><span style=""font-size:16px;"">������ ����� (�������� ����, �������;&nbsp;�����, ����������);</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">������ ��������, �������� �� ��������� ���������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������������� ��������, �� � ����������� ����� �������� �����, �� ������ ����������������� � �������� ���;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">����� ����� �������� �� ��� ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� �����, ���`��, ��������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������, �� ��������� �� ������������� ����������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� �������� �� �� ������ �� ����� �� ��������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ���������� � ����� �'�������� ���� �������� ��������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">����������� ��������� �� ��������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">����������� ������� ���������� � ���������� �� ��������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">������������� ����� �� ��������, ��������� �� �������� ����� ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">����������� ����� �������� �� ������� ���������� ���� ����� ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">ʳ������ ���� �� ����� 8-10 � ����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">������� ������� � ���������� �� �����������.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#008000;""><span style=""font-size:18px;""><strong>�������� �� ������ ��� ��������:</strong></span></span></p>

<hr>
<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/persha_skhodinka_do_znan/0-20""><span style=""color:#FF8C00;"">г���� ""��������""</span></a></strong><span style=""color:#FF8C00;"">&nbsp;</span>(��� �� 2-� �� 3-� ����)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/druga_skhodinka_do_znan/0-21""><span style=""color:#EE82EE;"">г���� ""���������""</span></a></strong><span style=""color:#EE82EE;"">&nbsp;</span>(��� �� 3-� �� 4-� ����)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/tretja_skhodinka_do_znan/0-22""><span style=""color:#40E0D0;"">г���� ""���������""</span></a></strong><span style=""color:#40E0D0;"">&nbsp;</span>(��� �� 4-� �� 5-�� ����)</span></p>

<p><span style=""font-size:16px;""><strong><a href=""http://www.raiduga.kiev.ua/index/chetverta_skhodinka_do_znan/0-26""><span style=""color:#0000CD;"">г���� ""������""</span></a></strong>&nbsp;(��� �� 5-�� �� 6-�� ����)</span></p>

<p>&nbsp;</p>

<p id=""they_head"" style=""text-align: center;""><span style=""color:#B22222;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;""><strong>�����������</strong></span></span></span></p>

<p><span style=""font-size:18px;""><span style=""color:#006400;""><strong>�������� ������� ���������� � ���� ���������� ���:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">��������� ����� ������� ������������ �������� � ����������, ����� ����������� �� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� �������� �� �����䳿, ����� ���������� ��� 䳿 ��������� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� ����������� ���� ������, ���������� ��� ����������� ������� �� ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ��������� ������ �������� �� ������ ��������, ��������� ������ � ������ �� ��������.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""font-size:18px;""><span style=""color:#006400;""><strong>�������� ������� ��������:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">��������� �������� �� ������ ��������� ���� ������ �� ����������&nbsp;���;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">���������� �������� ������� ���������� � �������� �� ��������� ��������� ���� ���������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ������������� �� �������� �� ��������� ��������� ���� ��������� �� ��� �����䳿 � ����������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ��������, ����� �������� ����������� �������.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>�������� ���������������� ��������� ����������:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� ������������ �� ��������� �����, �������������� ��������� �� ��������� ��;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� ��������� �� ����������� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� ������� ���� ����� ����� � ��������� ���� �� ������ ����� 䳿 ��� ��䳿.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>���������� �������������� �����:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">�������� �������������� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ��������� ����������� �������� �� ������������ �������� ����� ���� ����'������ ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ����� ����������� �����.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>�������� ���'��:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">�������� ���������������� �����'���������� �� �����������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ������� ������������ �������� ��'���� �� ��'������ �� ������� ������������ �����'����������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">���������� ��'��� ���'�� �� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ��������� ���'�� � ����������.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>�������� ��������:</strong></span></span></p>

<hr>
<ul>
 <li>
 <p><span style=""font-size:16px;"">�������� ����������� ������� ���� �� �� �������� ����������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ��������� ����������� �������� ������� �������� � ���������� �� ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ������� ������� ��� ��������� ���;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ��������� ������������� ������ �� ������� ������� ������������ ��'����, ������������ �� ��������� �� ������.</span></p>
 </li>
</ul>

<p>&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><strong>ϳ�������� ���� ���������� ��� �� �������� �������:</strong></span></span></p>

<hr>
<ul>
 <li><span style=""font-size:16px;"">��������� �������� ������� ����� ��������;</span></li>
 <li>
 <p><span style=""font-size:16px;"">��������� �������� ������� ������� �������� �������� �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� 䳺� ���������� �������� �� ����� � �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� ������� �������� ��������� ����� ������ �� ��������� ��������, ������� ��������� ��������� ����� ������� ������ �����;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� ������ ����, ���������� �� ��������� �������� �� �� ��������������� �������� ������ ������;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">��������� �������� �������� � ��������� �����, ���������� ����� ���;</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">�������� � ������ �������� �� ��������� ������� ������ �� ������� (������� ����� �� ������� ����);</span></p>
 </li>
 <li>
 <p><span style=""font-size:16px;"">���������� � ������ ���� ��� ������������� ��������� �� ������ �����.</span></p>
 </li>
</ul>

<p>&nbsp;</p>
</div>"
			});

			#endregion

			#region ������ � �����
			preSchollService.Courses.Add(new Course
			{
				Name = "������ � �����",
				Description = "������ � �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				BodyHtml = @"<div id=""they"" style=""font-family: Verdana, Geneva, sans-serif; color: #000; font-size: 11px"">
<p id=""they_head"" align=""center""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><strong><span style=""color:#000000;"">����</span><span style=""color: #ff0000""> </span><span style=""color:#FF8C00;""><u>�<b>��������� � �����</b>�</u></span></strong></span></span></p>

<p align=""center""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:20px;""><strong><span style=""color: #ff0000""><img alt="""" src=""/mama.jpg"" style=""width: 500px; height: 306px;""></span></strong></span></span></p>

<p style=""text-align: center;""><span style=""color:#FFA500;""><span style=""font-family:verdana,geneva,sans-serif;""><strong><span style=""font-size:18px;"">��&nbsp;����� ������� ���, ��&nbsp;������&nbsp;�������&nbsp;�����&nbsp;���� ������&nbsp;�������, ����������� �� ���������!</span></strong></span></span></p>

<hr>
<blockquote>
<p><span style=""display: none;"">&nbsp;</span><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">����� ���� ������ ������ - �� ���� �&nbsp;�������&nbsp;�����.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">����� �� ��������� ����&nbsp;���������� �� ���� �����&nbsp;�� ����, ������ ���� � &nbsp;�����, ������� ����������� � ����� ���� � �����.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">� ������� - �� ������� ������&nbsp;���������&nbsp;�� �������� ����������� � ����, � ���, � ����� !!!</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">���� ��������� ���������� ����� ��������� ��������� ����� ������� �����������, ����������� � ���������, ���������� ���������&nbsp;��&nbsp;�������� �����, ������� �������.</span></span></span></p>

<p><span style=""color:#800000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:16px;"">�� ���������� ������� ����� �������� ���� ������ ��&nbsp;��������� � ����������.</span></span></span></p>
</blockquote>

<p><span style=""display: none;"">&nbsp;</span>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><span style=""font-size:16px;""><span style=""font-size:18px;""><span style=""color:#008000;""><strong>������� �������� �����</strong></span></span></span><span style=""font-size:16px;""><strong><u> </u></strong></span></p>

<hr>
<ol>
 <li><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""color:#FF8C00;""><strong>�������� �����</strong></span></span> ���������� ������ ����-������������, �� �&nbsp;</span><span style=""font-size: 16px; line-height: 1.6;"">�������� ����� ���������� ��������. ����� ������� ���������� � �������� ���������� �����, �� ������� ������������������.</span></li>
 <li><span style=""font-size:16px;""><span style=""color:#DAA520;""><span style=""font-family:verdana,geneva,sans-serif;""><strong>������� ������� ���������</strong></span> </span>&ndash; �������� ����� ������� <u>��</u> ���������.</span></li>
 <li><span style=""font-size:16px;""><span style=""color:#40E0D0;""><strong>������ ������ �����:</strong></span><span style=""color:#FF8C00;""> </span>�������� ����� ��������, ���������� ����� ������, �� ��������, �����������, ���������� ��������� ������� ��� ��������� ���.</span></li>
</ol>

<p style=""text-align: center;"">&nbsp;</p>

<p><span style=""font-size:16px;""><span style=""color:#EE82EE;""><b><i>���� ������������</i></b>&nbsp;</span><span style=""color:#000000;"">�� ������� ���� ������ ������������&nbsp;� ��������� �����������, ����� ���������, ������� ��� ��� �����, ������������ ���������, ����������� ��������� (�����������). �������� � ��� ����� ��������� �� ��������, ����� ���������� �� ��������, ������ ��������, �� ���������� � ���������� ��������� ��������� ������.</span></span></p>

<p><span style=""font-size:16px;""><span style=""color:#FFD700;""><em><strong>���� �������������� ��������.</strong></em></span> <span style=""color:#000000;"">�������� �� ������ ���� ������� ������� �� ��� ������, ��� � ��� ���������. � ��� ����� �������������� ����� ������� �� ������� � ����������. � ������ ������� ������ �������� ����'������ ��������� ��� ��� �������������� ���������� � ������ �������, ������� ����� ��� �������� � ��������� �� �� ����������. � ���������, ����� ������������� ����� �������� ��������� ��������� �� ����� ���� �������� � ������ � ������, �� ��������� �������� ����� ������ �� � ������� ��������, �� ���������� ��������� ������, ��� � �������� ������� �������.</span></span></p>

<p><span style=""font-size:16px;""><strong><span style=""color:#0000FF;"">���� �����������.</span></strong><span style=""color:#000000;"">&nbsp;�������� ��������� �� �������� ����� ����� �������� ������� ������: �� ����� �� ��� ��������� ������� ����������� � ����� ���������� �� ���������;&nbsp;�� ����� ������ ��������� ��������;&nbsp;���� ���� ���� ���������� �&nbsp;������, �� ���� ��������?</span></span></p>

<p><span style=""font-size:16px;"">&nbsp;</span></p>

<p><span style=""color:#800000;""><b><strong><span style=""font-size:16px;"">ϳ� ��� ����������� ����� ""��������� � �����"" ����� ������������ � �����, �� ���� �����, ������� �������, ������, �����, �������, ����� ��������� ���������� ��� ����� ������ � ��������, ����������� ����� ��������, ��������� ����� �� ������� �������� ������������, ������ ����� ���, ����� �� ��������.</span></strong></b></span></p>
</div>"
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
				Name = "���������� ����",
				Description = "���������� ����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				PriorityOrder = 1,
				Price = "110",
				BodyHtml = @"<div id=""posts"">
 <!-- <body> --><div id=""nativeroll_video_cont"" style=""display:none;""></div><p style=""text-align: center;""><strong><span style=""color:#006400;""><span style=""font-size:24px;""><span style=""font-family:comic sans ms,cursive;""><u>""English Club""</u></span></span></span></strong></p>

<p style=""text-align: center;""><img alt="""" src=""/Funny-English.jpg"" style=""width: 434px; height: 376px;""></p>

<p style=""text-align: center;"">&nbsp;</p>

<p><span style=""color:#006400;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">����� �� ��� ����쳺, �� � ��������� ��������� ������ ��������� ���� � �� ������ ��������, � ���������� �� � �����, ��� � � ����.</span></span></span></p>

<hr>
<p><span style=""color:#000000;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">���������� ������� �� ���� ������ �� ��� �����, ������ ������� ������������ ������ ����������� ������, ������ �����&nbsp; ��� �� ������. � �� ���������, ���� � ������� ���� �� ����� �������� ���. ��� ����� �� �������� ��������, ��� ������ ���� ���������.</span></span></span></p>

<p>&nbsp;</p>

<p><span style=""color:#000000;""><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">���� � ���� ������ �������� � ���������� � ����, �� �� ������ ������ ��������� ������ � �������� ���� �� ������� ����� &ndash; �� ���������� ���.</span></span></span></p>

<p><span style=""font-size:18px;""><span style=""font-family:verdana,geneva,sans-serif;"">� ��� �� �������� ��������� �������� ����� �� �������� ���������, �� ������ � ������������ ���� ���������.</span></span></p>

<p>&nbsp;</p>

<p><span style=""color:#008000;""><strong><span style=""font-size:16px;"">������ �� ��� �� ��������� ������� � ������������.</span></strong></span></p><!-- </body> -->
 </div>"
			});


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
				Name = "��������� �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Price = "100",
				PriorityOrder = 1,
				Description = "����� �����",
				BodyHtml = @"<p>���� �������� �����, �� ������� �� ���� ������� &mdash; ��, � ����� �����, ��������,����� �������� �� ����� �����������. ����, ����� �� �����, ������ ����������� �� ���� �����. ����������� ������ ���������� ���� ���, ������� � �����, �������� ������, ������� � ���������� � ����� ����. ������ ��� ���������, � ����� ����� �� ������ �������� ��� �������� � ������� ���� �� ������� ���������.
</p>"
			});

			#region C����� �����

			adultService.Courses.Add(new Course
			{
				Name = "����������� �����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
				Description = "����������� �����",
				Price = "100",
				PriorityOrder = 2,
				BodyHtml = @"<div id=""they"" style=""font-family: Verdana, Geneva, sans-serif; color: rgb(0, 0, 0); text-align: justify;"">
<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/1319540326_269140600_1-Mtv-style-Dance-city-.jpg"" style=""float:left; width:175px; padding: 0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#008000;""><span style=""font-size:24px;""><span style=""font-family:comic sans ms,cursive;""><strong><u>MTV-style</u>.&nbsp;</strong></span></span></span><span style=""font-size:16px;"">�� �� ������ ����� �����,&nbsp;�&nbsp;���� ����'� ������������ ��������, ������� � ���� ����. ��� ������� ����� ���-����, ������� � house, ��������, �������� �����, �����, �������� ������. ������, ��������� � ���������� ��������� ��������� � ��������� � ����������. MTV-style ������������&nbsp;�� �������, ��������� � ����� �����, � ���� ���� ��� ����� ������� �� ����� �'��� � ������ �������� ����������� ������.</span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>
&nbsp;

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/jazz-funk.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#40E0D0;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><u><strong>����-����</strong></u><strong>.</strong></span></span></span><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;"">&nbsp;<span style=""font-size:16px;"">�����, �� ������&nbsp;�&nbsp;��� �������� ����� � ������ �������, ����������� � ������, ��������� � ���������, ������ �� �� ���������� ����. ������� ���� �������, ������, ���������� �����, ������������ �, �������, �� ���� ����� ����������. ��� ������ ������� ��������, ��������, �����������, � ����� ����� ������� ������� � ����������. �����������, ������, ��������� &ndash; ������ ������� ����-�����.</span></span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><br>
<br>
&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/contemporary-Dance.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""font-size:18px;""><span style=""font-size:24px;""><span style=""color:#696969;""><u><strong>Contemporary dance</strong></u><strong>.</strong></span></span> </span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">����� ��������� ��������� �����. ����� ���������� ������. ��������� ���, �� ������� ����� �������� �������� ����������, ����� ������ ����, ���� �����䳿 � ���������, ���������, �����. � ��������� ��� contemporary dance ���������� �� ���� �������� ����������, ��� � ����, �� �� ���� ����� �� ������&nbsp;������� ��������.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;&nbsp;<img alt="""" src=""/7c4be12e95c2fc51ce672833a6ad4f07.jpeg"" style=""width: 153px; height: 118px;"">&nbsp;&nbsp; &nbsp;&nbsp;<span style=""color:#FF8C00;""><u><strong><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;"">����� �����.</span></span></strong></u></span> <span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">����� �������������� ����� ����� ����� ���� ��������� ���� ����������. �� ��������� ��������� ��� ������ - ����� ����� �</span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">���������������!&nbsp;������� ����, ��������, ������������, �������. ͳ�� ����䳿 �� �������� ���� ���������� ��� ���������� </span></span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">� ������� �� ������ ���������� � ���.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/pilates5.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><span style=""font-family:comic sans ms,cursive;""><span style=""color:#000000;""><span style=""font-size:24px;""><u><strong>ϳ�����</strong></u><strong>.</strong></span></span></span><span style=""font-size:14px;""> </span><span style=""font-size:16px;""><span style=""font-family:verdana,geneva,sans-serif;"">������� �����������, ������� ��������, ����� �������� ������� � ��������. ������� �������� ������ ����� ����-����� ��� � ����, ���, ��� ���� ����� ��������� � ���� � ������ ����. ³� � ����� � ������������� ���� ����������, �� �� �'��� �� �� ���, ��������� �������� ����.</span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><br>
<br>
<br>
<br>
<br>
&nbsp;</p>

<p style=""font-size: 11px;""><img src=""http://www.raiduga.kiev.ua/News/img/strip_2.jpg"" style=""float:left; width:175px; padding:0px 10px 10px 10px""></p>

<p style=""font-size: 11px;""><span style=""color:#808080;""><span style=""font-family:comic sans ms,cursive;""><span style=""font-size:24px;""><u><strong>Strip-dance</strong></u><strong>.</strong></span></span></span><span style=""font-size:16px;""><span style=""color:#000000;""><span style=""font-family:verdana,geneva,sans-serif;""><span style=""line-height: 17.6000003814697px;"">����</span>&nbsp;� ���������� �������� � ������� ������. ������� ���� ����� �� ����� ������ � �������� �����, ��� � ������� � ��� ��� ��������� , �����&nbsp;�����������. �� ��������� ���� ���! ���� ���� � ������� �����&nbsp;�� ����� �������� �� ����� ���, ��� � �������� ����.</span></span></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;""><span style=""color:#696969;""><strong><u><span style=""font-size:16px;"">������ �� ��� �� ��������� ������� � ������������!</span></u></strong></span></p>

<p style=""font-size: 11px;"">&nbsp;</p>

<p style=""font-size: 11px;"">&nbsp;</p>
</div>"

			});

			#endregion

			#region ������

			adultService.Courses.Add(new Course
			{
				Name = "Գ����",
				Description = "Գ����",
				CreationDate = DateTime.Now,
				Duration = new TimeSpan(0),
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
					BodyHtml = @"<br />
	<br />
	<div class=""row"">
		<div class=""col-md-2 col-md-offset-2"">
			<img src=""~/Content/img/logo 500x422.png"" class=""img-responsive"" />
		</div>
		<div class=""col-md-6"">
			�������� ������ DiRT Showdown ���� �������� ��������� Codemasters � 2012 ����.
			�������� ������������� ���� �������� ������ ���������������� �����, �������� ������� �� ����� Flatout �� ������ Bugbear.
			����� � ���� ������������ ����� �� ���������� �������, ����������� �� 8 �������,
			� ����� ����� ������������ ������ Split Screen, ����������� ������� ������ �� ����� ����������.
		</div>
	</div>
	<br />
	<br />
	<h3 class=""text-center""><strong>���� ����������</strong></h3>
	<br />
	<div class=""row"">
		<div class=""col-md-6 col-md-offset-3"">
			<div class=""media"">
				<div class=""media-left"">
					<div class=""media-object"">39</div>
				</div>
				<div class=""media-body"">
					<h4 class=""media-heading"">����������</h4>
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
					<h4 class=""media-heading"">�������� �� ���</h4>
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
					<h4 class=""media-heading"">������������</h4>
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
					<h4 class=""media-heading"">����������</h4>
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
					<h4 class=""media-heading"">��������</h4>
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
					<h4 class=""media-heading"">��� �����</h4>
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
					<h4 class=""media-heading"">�����</h4>
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
					<h4 class=""media-heading"">������</h4>
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
				<img src=""../Content/img/features/����.svg"" />
				<h4>�� ���������� ����� ����������, ��������� �� �������� ������ �����: ���������, �����, ������ ���������� ����, ������� �� ������, �� �����.</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/��������.svg"" />
				<h4>�� �������� ���� �� ���������� ����� �� ����� ��������� � ������</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/����.svg"" />
				<h4>�� �������� ������� ������� �� �ᒺ����� ����� �� ��� �����</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/������.svg"" />
				<h4>�� ��������� ��������� ����� �� ����� ������, ���������� ���� � �������� ����� ������� ���� ������, ���������� ����� �쒿 �������� �����������, ������, ���������, ������.</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/����.svg"" />
				<h4>�� ������ ����� ������� ��������� � ���������� �������� ������� ��������� ������ �����</h4>
			</div>
			<div class=""col-md-6"">
				<img src=""../Content/img/features/����.svg"" />
				<h4>�� ������ �� ����� ���������� �� ����</h4>
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
