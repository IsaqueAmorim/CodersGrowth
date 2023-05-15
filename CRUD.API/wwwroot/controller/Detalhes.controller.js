sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/model/json/JSONModel",
], function(Controller, formatter,JSONModel) {
    'use strict';
    
    return Controller.extend("sap.ui.api.jogadores.controller.Detalhes",{

        formatter: formatter,
        onInit: function() {
            var rota = this.getOwnerComponent().getRouter();
        rota.getRoute("tabelaDePets").attachMatched(this.aoCoincidirRota, this);
        },
        aoCoincidirRota: function (evento) {
            var parametros = evento.getParameters();
            var id = parametros.arguments.id;
            this.obterDados(id);
          },
          obterDados: function(id){

			let jsonModelJogador = new JSONModel();
			fetch("http://localhost:5124/v1/jogadores/" + id)
				.then(response => response.json())
				.then(response => jsonModelJogador.setData({jogadores : response}))
			this.getView().setModel(jsonModelJogador);
		}
       

    });
});