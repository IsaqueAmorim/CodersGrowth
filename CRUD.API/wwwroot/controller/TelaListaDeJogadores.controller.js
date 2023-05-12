sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/model/json/JSONModel",
 ], function (Controller,formatter,Filter,FilterOperator,JSONModel) {
    "use strict";
    return Controller.extend("sap.ui.api.jogadores", {
        formatter : formatter,
        aoDigitar: function (oEvent) {
			
			var filtro = [];
			var buscar = oEvent.getParameter("query");
			if(buscar){
				filtro.push(new Filter("nome", FilterOperator.Contains, buscar));
			}

			var tabela = this.byId("tabela_jogadores")
			var items = tabela.getBinding("items");
			items.filter(filtro);
			
		},
		onInit : function(){

			var jsonModelJogador = new JSONModel();
			fetch("http://localhost:5124/v1/jogadores/",{method: "GET"})
				.then(response => response.json())
				.then(response => jsonModelJogador.setData({jogadores : response}))
			this.getView().setModel(jsonModelJogador);
			
		}
    });
 });