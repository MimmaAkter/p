using Student_InfoApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Student_InfoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ServiceReference1.Service1SoapClient client = new ServiceReference1.Service1SoapClient(); 
        public MainPage()
        {
            this.InitializeComponent();
            List<string> Exam = new List<string> { "Masters", "Pass Course"};
            cmbex.ItemsSource = Exam;
            List<string> Board = new List<string> { "Dhaka", "Chittagong", "Khulna", "Borisal", "Rajsahi", "Sylet" };
            cmbB.ItemsSource = Board;
        }

        

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Student_Info student_info = new Student_Info();
                student_info.Name = txtname.Text;
                student_info.Registration_No = txtr_no.Text;
                student_info.Exam = cmbex.SelectedItem.ToString();
                student_info.Sesson = txtson.Text;
                student_info.Board = cmbB.SelectedItem.ToString();
                student_info.Contact_No = txtc_on.Text;
                var result = client.InsertAsync(student_info);
               
                if(result.Result.Body.InsertResult>0)
                {
                    ClearControl();
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Insert Success");
                    mesg.ShowAsync();
                    
                }
                else
                {
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Insert Failed");
                    mesg.ShowAsync();
                }
                
                
            }
            catch(Exception exp)
            {
                Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog(exp.Message.ToString());
                mesg.ShowAsync();
            }
        }
        private void ClearControl()
        {
            txtname.Text = "";
            txtr_no.Text = "";
            txtson.Text = "";
            txtc_on.Text = "";
            cmbB.SelectedValue = "";
            cmbex.SelectedValue = "";
            
        }

        

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = client.SearchAsync(txtr_no.Text);
                if (result.Result.Body.SearchResult != null)
                {
                    Student_Info stu_info = result.Result.Body.SearchResult;
                    this.DataContext = stu_info;
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Sreach Success");
                    mesg.ShowAsync();

                }
                else
                {
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Sreach Faild");
                    mesg.ShowAsync();
                }
            }
            catch(Exception exp)
            {
                Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog(exp.Message.ToString());
                mesg.ShowAsync();
            }
          
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = client.DeleteAsync(txtr_no.Text);
                if (result.Result.Body.DeleteResult > 0)
                {
                    ClearControl();
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Delete Success");
                    mesg.ShowAsync();
                }
                else
                {
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Delete Failed");
                    mesg.ShowAsync();
                }
            }
            catch(Exception exp)
            {
                Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog(exp.Message.ToString());
                mesg.ShowAsync();
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student_Info student_info = new Student_Info();
                student_info.Name = txtname.Text;
                student_info.Registration_No = txtr_no.Text;
                student_info.Exam = cmbex.SelectedItem.ToString();
                student_info.Sesson = txtson.Text;
                student_info.Board = cmbB.SelectedItem.ToString();
                student_info.Contact_No = txtc_on.Text;
                var result = client.UpdateAsync(student_info, txtr_no.Text);
                if(result.Result.Body.UpdateResult>0)
                {
                    ClearControl();
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Update Success");
                    mesg.ShowAsync();
                }
                else
                {
                    Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog("Update Failed");
                    mesg.ShowAsync();
                }
                
            }
            catch(Exception exp)
            {
                Windows.UI.Popups.MessageDialog mesg = new Windows.UI.Popups.MessageDialog(exp.Message.ToString());
                mesg.ShowAsync();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtname.Text = "";
            txtr_no.Text = "";
            txtson.Text = "";
            txtc_on.Text = "";
            cmbB.SelectedValue = "";
            cmbex.SelectedValue = "";
        }
    }
}
