using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToDoC
{
    public partial class Form1 : Form
    {
        private List<ToDoItem> toDoItems;
        public Form1()
        {
            InitializeComponent();
            toDoItems = new List<ToDoItem>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string todoItem = todoTextBox.Text;

            if(!string.IsNullOrWhiteSpace(todoItem))
            {
                DateTime date = dateTimePicker.Value.Date;
                ToDoItem newItem = new ToDoItem(date, todoItem);
                toDoItems.Add(newItem);

                UpdateToDoList();
                todoTextBox.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (todoListBox.SelectedIndex != -1)
            {
                toDoItems.RemoveAt(todoListBox.SelectedIndex);
                UpdateToDoList();
            }
        }

        private void UpdateToDoList()
        {
            todoListBox.Items.Clear();

            foreach (ToDoItem item in toDoItems)
            {
                todoListBox.Items.Add(item.ToString());
            }
        }

        public class ToDoItem
        {
            public DateTime Date { get; set; }
            public string Item { get; set; }
            public bool IsCompleted { get; set; }

            public ToDoItem(DateTime date, string item)
            {
                Date = date;
                Item = item;
                IsCompleted = false;
            }

            public override string ToString()
            {
                string completionStatus = IsCompleted ? "완료" : "미완료";
                return $"{Date.ToShortDateString()}: {Item} ({completionStatus})";
            }
        }


        private void todoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (todoListBox.SelectedIndex != -1)
            {
                int selectedIndex = todoListBox.SelectedIndex;
                toDoItems[selectedIndex].IsCompleted = true;
                UpdateToDoList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void todoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
