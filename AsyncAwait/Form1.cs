using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        List<Employee> employees;
        List<Student> students;
        List<Book> library;
        List<Item> shop;
        public Form1()
        {
            InitializeComponent();

            employees = new List<Employee>
            {
                new Employee("Patrick", new DateTime(2001, 12, 26), "38000000021", "Kyivska 34"),
                new Employee("Tom", new DateTime(1901, 6, 3), "38000000031", "Kyivska 28"),
                new Employee("Oleg", new DateTime(1925, 6, 3), "38000000036", "Lvivska 3")
            };
            students = new List<Student>
            {
                new Student("Vlad","KNP-213",12,8,7,new DateTime(2023, 4, 1)),
                new Student("Nikita","KNP-213",2,2,2,new DateTime(2023, 3, 28)),
                new Student("Bruh","KNP-213",6,12,12,new DateTime(2023, 4, 1))
            };
            library = new List<Book> {
                new Book("1234","Krown","Bruh","SEGA","2023",new DateTime(2023,4,28),new DateTime(2023,6,28)),
                new Book("1313131","GDGDG","Bruh 2","SEGA","2018", new DateTime(2021,6,29),new DateTime(2021,7,29)),
                new Book("13211211","GDGDG","Bruh 3","SEGA","2018", new DateTime(2018,6,29),new DateTime(2021,7,29))
            };
            shop = new List<Item>
            {
                new Item("Meat","Chicken","Ryaba",new DateTime(2023,2,4),15),
                new Item("Meat","Beaf","Super_Beef",new DateTime(2021,2,1),12),
                new Item("Fish","Hake","Black Sea", new DateTime(2020,2,2),12)
            };
        }
        public async void Task_6(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            void Task_6Engine(){
                foreach (var item in employees)
                {
                    if (item.address.Contains(textBox1.Text))
                    {
                        ListViewItem list_item = new ListViewItem(item.name);
                        list_item.SubItems.Add(item.phone);
                        listView1.Items.Add(list_item);
                    }
                }
            }
            await Task.Run(() => Task_6Engine());
        }
        public async void Task_7(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            void Task_7Engine()
            {
                foreach (var item in employees)
                {
                    if (item.date.Year == numericUpDown1.Value)
                    {
                        ListViewItem list_item = new ListViewItem(item.name);
                        list_item.SubItems.Add(item.phone);
                        listView2.Items.Add(list_item);
                    }
                }
            }
            await Task.Run(() => Task_7Engine());
        }
        public async void Task_8(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            void Task_8Engine()
            {
                foreach (var item in students)
                {
                    if (item.last_exam.Year >= numericUpDown1.Value)
                    {
                        ListViewItem list_item = new ListViewItem(item.name);
                        list_item.SubItems.Add(item.math_grade.ToString() + " " + item.phys_grade.ToString() + " " + item.inform_grade.ToString());
                        listView3.Items.Add(list_item);
                    }
                }
            }
            await Task.Run(() => Task_8Engine());
        }
        public async void Task_9(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            void Task_9Engine()
            {
                foreach (var item in library)
                {
                    if (DateTime.Now.AddDays(5) > item.time)
                    {
                        TimeSpan ts = DateTime.Now.Subtract(item.time);
                        int diff = Convert.ToInt32(ts.TotalDays);
                        ListViewItem list_item = new ListViewItem(item.title);
                        list_item.SubItems.Add(diff.ToString());
                        listView4.Items.Add(list_item);
                    }
                }
            }
            await Task.Run(() => Task_9Engine());
        }
        public async void Task_10(object sender, EventArgs e)
        {
            listView5.Items.Clear();
            void Task_10Engine()
            {
                foreach (var item in shop)
                {
                    if (numericUpDown1.Value > item.time.Year)
                    {
                        ListViewItem list_item = new ListViewItem(item.item_name);
                        listView5.Items.Add(list_item);
                    }
                }
            }
            await Task.Run(() => Task_10Engine());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task_6(sender,e);
            Task_7(sender, e);
            Task_8(sender, e);
            Task_9(sender, e);
            Task_10(sender, e);
        }
    }


    public class Employee
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public Employee(string name, DateTime date, string phone, string address) { 
            this.name = name;
            this.date = date;
            this.phone = phone;
            this.address = address;
        }
    }
    public class Student
    {
        public string name { get; set; }
        public string group { get; set; }
        public uint math_grade { get; set; }
        public uint phys_grade { get; set; }
        public uint inform_grade { get; set; }
        public DateTime last_exam { get; set; }
        public string address { get; set; }
        public Student(string name, string group, uint math_grade, uint phys_grade, uint inform_grade, DateTime last_exam)
        {
            this.name=name;
            this.group=group;
            this.math_grade=math_grade;
            this.phys_grade=phys_grade;
            this.inform_grade=inform_grade;
            this.last_exam=last_exam;
        }
    }
    public class Book
    {
        public string ticket_number { get; set; }
        public string author_name { get; set; }
        public string title { get; set; }
        public string publisher { get; set; }
        public string year { get; set; }
        public DateTime get_date { get; set; }
        public DateTime time { get; set; }

        public Book(string ticket_number, string author_name, string title, string publisher, string year, DateTime get_date, DateTime time)
        {
            this.ticket_number = ticket_number;
            this.author_name = author_name;
            this.title = title;
            this.publisher = publisher;
            this.year = year;
            this.get_date = get_date;
            this.time = time;
        }
    }

    public class Item
    {
        public string item_type { get; set; }
        public string item_name { get; set; }
        public string publisher { get; set; }
        public DateTime time { get; set; }
        public double best_before_days { get; set; }
        public Item(string item_type, string item_name, string publisher, DateTime time, double best_before_days)
        {
            this.item_type = item_type;
            this.item_name = item_name;
            this.publisher = publisher;
            this.time = time;
            this.best_before_days = best_before_days;
        }
    }
}
