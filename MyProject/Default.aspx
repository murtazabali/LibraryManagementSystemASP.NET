<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 410px;
            float:none;
            padding-left:3em;
        }
        .auto-style2 {
            width: 410px;
            height:150px;
            float:none;
            padding-left:3em;
        }
        .auto-style3 {
            width: 410px;
            height: 193px;
            float:none;
            padding-left:3em;
        }
        .auto-style5{
            padding-left:16.5em;
        }
         </style>
</head>   
<body>
    
    <form id="form1" runat="server">
        <table>
            <tr>
                <td class="auto-style1">Member ID:
                    <asp:TextBox ID="tbMember" runat="server" AutoPostBack="True" OnTextChanged="tbMember_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style1">Book ID:
                    <asp:TextBox ID="tbBook" runat="server" AutoPostBack="True" OnTextChanged="tbBook_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <div style ="height:300px; width:400px; overflow:auto; padding-top:2em" >
                    <asp:DetailsView ID="dvMember" runat="server" Height="50px" Width="300px" Font-Bold="False" HeaderText="Members">
                        <HeaderStyle BorderStyle="None" Font-Bold="True" ForeColor="#006600" HorizontalAlign="Center" Wrap="True" />
                    </asp:DetailsView>
                    </div>
                </td>
                <td class="auto-style2">
                    <div style ="height:300px; width:400px; overflow:auto; padding-top:2em">
                    <asp:DetailsView ID="dvBook" runat="server" Height="50px" Width="300px" HeaderText="Books">
                        <HeaderStyle BorderStyle="None" Font-Bold="True" ForeColor="#006600" HorizontalAlign="Center" />
                    </asp:DetailsView>
                    <asp:LinkButton ID="lnkIssue" runat="server" OnClick="LnkbuttonIssue" CssClass="auto-style5">Issue</asp:LinkButton>
                    </div>
                                            
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <div style ="height:160px; width:400px; overflow:auto; padding-top:1em" >
                    <asp:GridView ID="gvIssue" runat="server" AutoGenerateColumns="False" Height="100px" Width="300px" HeaderText="Issued Books">
                      <HeaderStyle BorderStyle="None" Font-Bold="True" ForeColor="#006600" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Title">
                                <HeaderTemplate>
                                    Issued Books<br /> -------------------<br />Title
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnktitle" Text='<%# Eval("title") %>' runat="server" OnClick="LnkbuttonGridview"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
