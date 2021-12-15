<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AulaWebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Título dá página!</title>
    <script src="https://code.jquery.com/jquery-1.11.3.js"></script>
    <script type="text/javascript">

        function ajax1()
        {
            $.ajax
            ({
                type: "POST",
                url: "Default.aspx/alerta1",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data)
                {
                    alert(data.d);
                },
                error: function ()
                {
                    alert("Falha ao acessar o webservice!");
                }
            });
        }

        function ajax2()
        {
            $.ajax
            ({
                type: "POST",
                url: "Default.aspx/alerta2",
                data: "{ valor: " + document.getElementById('textBox').value + "}",
                contentType: "application/json;  charset=utf-8",
                dataType: "json",
                success: function (data)
                {
                    document.getElementById("label").innerHTML = data.d;
                    //alert(data.d);
                },
                error: function ()
                {
                    document.getElementById("label").innerHTML = "Erro!";
                }
            });
        }

    </script>
</head>
<body style="background-color:lightgreen">
    <form id="form1" runat="server" >
        <div>
            <asp:Label ID="label" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:TextBox ID="textBox" runat="server"></asp:TextBox>
            <br /><br />
            
            <input id="btnAjax1" type="button" value="Ajax 1" onclick="ajax1();"/>
            <input id="btnAjax2" type="button" 
                value="Ajax 2 - Dobro do valor" onclick="ajax2();"/>
            
            <br /><br /><br /><br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>


           <%-- <div id="minhaDIV" runat="server">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>--%>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Clique aqui" 
                OnClick="Button1_Click" />
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </asp:Panel>


            <br /><br /><br /><br />
            <asp:Button ID="btnAlert" runat="server" 
                Text="Alerta1" OnClick="btnAlert_Click" />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>

        </div>
    </form>
</body>
</html>
