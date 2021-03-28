<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formula One</title>
</head>
<body>

    <style>
        #DropDownList1{
            width:20%;
            height:5%;
            margin: 10px 0px;
        }
        .rowsStyle{
            background-color:white;
            color:black;
        }
        .rowsStyle:nth-of-type(odd){
            background: #EEEEEE;
            color:black;
        }
    </style>

    <form id="form1" runat="server">
        <div>
            <asp:Label id="lblMessaggio" runat="server" Text=" "> </asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:GridView ID="GridViewTable" runat="server" RowStyle-CssClass="rowsStyle" >
                <headerstyle backcolor="White"
                        forecolor="Black"/>
            </asp:GridView>
            <asp:ListBox runat="server" ID="lbxNazioni">
                
            </asp:ListBox>
        </div>
    </form>
</body>
</html>
