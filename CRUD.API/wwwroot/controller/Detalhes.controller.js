sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/Formatador",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History"
], function(Controller, Formatador,JSONModel,History) {
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

		
			fetch("https://localhost:7139/v1/jogadores/" + id)
                .then(resposta => {
                    let dadosJogador = resposta.json();
                    this.getView().setModel(new JSONModel({jogador : dadosJogador}));
                })
		},
        aoClicarVoltar: function(oEvent){
            let historico = History.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                window.history.go(-1);
            }else{
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo("");
            }

        }
       

    });
});