var Lista = {

    API_URL: "",
    UsuarioID: "",

    ListaServicos: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
        that.BuscarServicos();
    },

    //Método para buscar usuario logado
    GetUsuario: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Usuario/GetUsuario?usuario_id=" + that.UsuarioID,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var usuario = response_done;

            if (usuario.id == "" || usuario.id == "undefined") {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para Recuperar todos os veterinarios
    BuscarServicos: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Servico/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_servicos = response_done;

            if (lista_servicos.length > 0) {

                that.ListaServicos = lista_servicos;
                that.CreateHTMLServicos();
                that.PosProcessSuccess();

            } else {
                that.PosProcessFail();
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            that.PosProcessFail();

        });

    },

    PreProcees: function () {
        $("#table_servicos").addClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").removeClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#table_servicos").removeClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#table_servicos").addClass("d-none");
        $("#content_list_message").removeClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    CreateHTMLServicos: function () {
        var that = this;

        if (that.ListaServicos.length > 0) {

            for (var i = 0; i < that.ListaServicos.length; i++) {

                var servico = that.ListaServicos[i];


                var option_view = "<img src='../Content/icons/view.png' class='icon-action m-1' title='Visualizar'>";
                var option_edit = "<img src='..//Content/icons/edit.png' class='icon-action m-1' title='Editar'>";
                var options = option_view + option_edit;

                var element = "";
                element += "<tr>";
                element += "<td scope='col' class='text-center'>" + (parseInt(i) + 1) + "</td>";
                element += "<td scope='col' class='text-center'>" + servico.id + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.nome + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.tempo + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.valor_atual + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.pataz_bonus + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.pataz_custo + "</td>";
                element += "<td scope='col' class='text-left'>" + servico.tipo_executante_descricao + "</td>";
                element += "<td scope='col' class='text-center'>" + options + "</td>";
                element += "</tr>";

                $("#table_servicos").append(element);

            }
        }
    }


}