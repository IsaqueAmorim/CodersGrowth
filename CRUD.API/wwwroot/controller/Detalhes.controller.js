sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History"
    
], function(Controller, Formatador,JSONModel,Historico) {
    'use strict';
    
    return Controller.extend("sap.ui.api.jogadores.controller.Detalhes",{

        formatter: Formatador,
        onInit: function() {
            var rota = this.getOwnerComponent().getRouter();
            rota.getRoute("detalhes").attachMatched(this.aoCoincidirRota, this);
        },
        aoCoincidirRota: function (evento) {
            var id = evento.getParameter("arguments").id;
            
            
            this.obterDados(id);
        },
          obterDados: function(id){

			let jsonModelJogador = new JSONModel();
			fetch("https://localhost:7139/v1/jogadores/" + id)
				.then(response => response.json())
				.then(response => jsonModelJogador.setData({jogador : response}))
			this.getView().setModel(jsonModelJogador);
		},
        aoClicarVoltar: function(oEvent){
            let historico = Historico.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo("home");
            }else{
               
                window.history.go(-1);
            }
        },
       

       

    });
});