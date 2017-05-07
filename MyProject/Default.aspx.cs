using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class Default : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (tbBook.Text == "")
            {
                lnkIssue.Visible = false;
            }
        }
        protected void tbMember_TextChanged(object sender, EventArgs e)
        {
            MembersDAO member = new MembersDAO();
            dvMember.DataSource = member.getMemberById(int.Parse(tbMember.Text));
            dvMember.DataBind();
            IssueDAO issue = new IssueDAO();                  
            gvIssue.DataSource = issue.getIssuedBooks(int.Parse(tbMember.Text));
            gvIssue.DataBind();
        }

        protected void tbBook_TextChanged(object sender, EventArgs e)
        {
            BooksDAO books = new BooksDAO();
            dvBook.DataSource = books.getBooksByBookId(int.Parse(tbBook.Text));
            dvBook.DataBind();
            IssueDAO issue = new IssueDAO();
            if(issue.IssuedBooks(int.Parse(tbBook.Text)) == 0)
            {   
                lnkIssue.Visible = false;                         
            }else
            {
                lnkIssue.Visible = true;
                lnkIssue.Text = "Issue";             
            }   
               
        }

        protected void LnkbuttonIssue(object sender, EventArgs e)
        {
            IssueDAO issue = new IssueDAO();
            ReturnDAO returnDao = new ReturnDAO();
           
            if (lnkIssue.Text == "Issue")
            {
                
                issue.InsertIssueBook(int.Parse(tbBook.Text), int.Parse(tbMember.Text));
                gvIssue.DataSource = issue.getIssuedBooks(int.Parse(tbMember.Text));
                gvIssue.DataBind();


                if (returnDao.getReturnBookInt(int.Parse(tbMember.Text)) == 0)
                {
                    lnkIssue.Visible = true;
                    lnkIssue.Text = "Issue";
                }
                if (issue.BooksCondition(int.Parse(tbMember.Text)) == 2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Member cannot issue more than two books!')", true);
                    lnkIssue.Visible = false;
                }
                else
                {
                    lnkIssue.Visible = false;
                }
            }
            if (lnkIssue.Text == "Return")
            {
                returnDao.ReturnBook(int.Parse(tbBook.Text));
                gvIssue.DataSource = returnDao.getReturnBooks(int.Parse(tbMember.Text));
                gvIssue.DataBind();
                if (returnDao.getReturnBookInt(int.Parse(tbMember.Text)) == 0)
                {
                    lnkIssue.Text = "Issue";
                }
                lnkIssue.Text = "Issue";
            }

        }

        protected void LnkbuttonGridview(object sender, EventArgs e)
        {
            lnkIssue.Visible = true;         
            LinkButton lnk = (LinkButton)sender;
            IssueDAO issue = new IssueDAO();
            BooksDAO books = new BooksDAO();
            int bookId = issue.getIssueBookInt(lnk.Text);
            tbBook.Text = bookId.ToString();
            dvBook.DataSource = books.getBooksByBookId(bookId);
            dvBook.DataBind();
            lnkIssue.Text = "Return";
        }
      
    }
}