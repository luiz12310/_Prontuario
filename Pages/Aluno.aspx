<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aluno.aspx.cs" Inherits="Prontuario.Pages.Aluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta charset="UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../Css/estiloAluno.css" />
<link href="https://fonts.googleapis.com/css2?family=Raleway:wght@200&amp;display=swap" rel="stylesheet" />
<title>Aluno</title></head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="litHeader" runat="server"></asp:Literal>
        <section>
            <asp:GridView ID="tblAluno" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo">
                    <HeaderStyle CssClass=".th" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nome" HeaderText="Nome">
                    <HeaderStyle CssClass=".th" />
                    </asp:BoundField>
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
            <br />
                <asp:GridView ID="tblDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Documento.nome" HeaderText="Documentos" >
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Registro"><ItemTemplate>
			        <asp:CheckBox runat="server" id="chk" Checked="<%# Bind('consta') %>"></asp:CheckBox>
			        </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Documento.codigo" HeaderText="Codigo"></asp:BoundField>
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
            <br />
            <div class="divBtnDocumento">
                <asp:Button ID="btnDocumento" runat="server" Text="Salvar Alterações" OnClick="btnDocumento_Click" />
            </div>
            <br />
            <asp:GridView ID="tblCursos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Curso.sigla" HeaderText="Sigla">
                    <ControlStyle BorderStyle="None" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Curso.nome" HeaderText="Nome do Curso">
                    <ControlStyle BorderStyle="None" />
                    </asp:BoundField>
                    <asp:HyperLinkField HeaderText="Informações" Text="ver mais" DataNavigateUrlFields="codigoCurso,codigoAluno" DataNavigateUrlFormatString="Aluno.aspx?cdcurso={0}&cdAluno={1}" >
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
            <br />
  
            <asp:Panel ID="pnlDiploma" Visible="false" runat="server">                    
            <asp:GridView ID="tblDiploma" runat="server" AutoGenerateColumns="False" OnLoad="tblDiploma_Load" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Curso.nome" HeaderText="Curso">
                </asp:BoundField>
                <asp:BoundField HeaderText="Nº diploma" DataField="codigoDiploma">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Conclusão" DataField="dataConclusao"></asp:BoundField>
                <asp:BoundField DataField="dataEmissao" HeaderText="Emissão">
                </asp:BoundField>
                <asp:BoundField DataField="dataRetirada" HeaderText="Retirada">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="codigoCurso,codigoAluno,codigoDiploma" DataNavigateUrlFormatString="Aluno.aspx?cdcurso={0}&amp;cdAluno={1}&amp;cdDiploma={2}" HeaderText="Ações" Text="Retirar">
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
            <br />
                <asp:Panel ID="pnlCursoEmAndamento" runat="server">
                    <asp:Literal ID="litEmAndamento" runat="server"></asp:Literal>
                </asp:Panel>
            <%--<div class="divBtnDocumentoOutro">
                <asp:Button ID="btnNovoDiploma" runat="server" Text="Segunda Via" OnClick="btnNovoDiploma_Click"/>
            </div>--%>
            </asp:Panel>    
            <div class="divBtnDocumento2">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>            
        </section>
    </form>
</body>
</html>
