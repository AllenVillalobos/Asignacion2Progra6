<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Asignacion2Progra6.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container shadow rounded mt-5">
            <div class="container text-center mt-5">
                <h1 class="txt-center mt4">Información de las Familias</h1>
                <div class="mx-auto">
                    <asp:FileUpload runat="server" ID="fileUpload" Accept=".xml" CssClass="form-control mb-3" />
                </div>
                <div class="text-center mt-3">
                    <asp:Button runat="server" ID="btnCargar" Text="Cargar Archivo XML" OnClick="btnCargar_Click" CssClass="btn btn-primary m-2" />
                    <asp:Button runat="server" ID="btnNombre" Text="Ordenar Por Nombre" OnClick="btnNombre_Click" CssClass="btn btn-secondary m-2" />
                    <asp:Button runat="server" ID="btnEdad" Text="Ordenar Por Edad" OnClick="btnEdad_Click" CssClass="btn btn-secondary m-2" />
                </div>
            </div>
            <div class="container shadow rounded m-2">
                <div class="container table-responsive text-center">
                    <h2 class="mt4">Lista de Padres</h2>
                    <asp:GridView runat="server" ID="gvPadres" AutoGenerateColumns="false" CssClass="table text-center align-middle table-bordered table-hover rounded p-2">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            <asp:BoundField DataField="Peso" HeaderText="Peso" />
                            <asp:BoundField DataField="Altura" HeaderText="Altura" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="container table-responsive text-center">
                    <h2 class="mt4">Lista de Madres</h2>
                    <asp:GridView runat="server" ID="gvMadres" AutoGenerateColumns="false" CssClass="table text-center align-middle table-bordered table-hover rounded p-2">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            <asp:BoundField DataField="Peso" HeaderText="Peso" />
                            <asp:BoundField DataField="Altura" HeaderText="Altura" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="container table-responsive text-center">
                    <h2 class="mt4">Lista de Hijos</h2>
                    <asp:GridView runat="server" ID="gvHijos" AutoGenerateColumns="false" CssClass="table text-center align-middle table-bordered table-hover rounded p-2">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            <asp:BoundField DataField="Peso" HeaderText="Peso" />
                            <asp:BoundField DataField="Altura" HeaderText="Altura" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
