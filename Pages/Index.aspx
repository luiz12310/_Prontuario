<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Prontuario.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta charset="UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../Css/estilogeral.css" />
<link href="https://fonts.googleapis.com/css2?family=Raleway:wght@200&amp;display=swap" rel="stylesheet" />
<title>Lista de Alunos</title>
</head>
<body>
    <form id="form1" runat="server">
        <section>
    <p class="titulo">Buscar Aluno</p>
    <br />
    <div class="ala">
        <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click1"/>
    </div>
    <br />
    <asp:GridView ID="tblAluno" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="codigo" HeaderText="Codigo">
            <HeaderStyle CssClass=".th" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="Nome">
            <HeaderStyle CssClass=".th" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="codigo" DataNavigateUrlFormatString="Aluno.aspx?cdAluno={0}" HeaderText="Ações" Text="ver mais" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</section>
    </form>
</body>
</html>
