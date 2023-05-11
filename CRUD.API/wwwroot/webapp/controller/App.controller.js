sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function (Controller,JSONModel,formatter,Filter,FilterOperator) {
	"use strict";

	return Controller.extend("sap.ui.api.jogadores.controller.App", {
		formatter : formatter,
		onInit : function(){

			var jsonModel = new JSONModel();
			fetch("https://localhost:7139/v1/jogadores/",{method: "GET"})
				.then(response => response.json())
				.then(response => jsonModel.setData({jogadores : response}))
			this.getView().setModel(jsonModel);
			
		},
		aoDigitar: function (oEvent) {
			
			var filtro = [];
			var buscar = oEvent.getParameter("query");
			if(buscar){
				filtro.push(new Filter("nome", FilterOperator.Contains, buscar));
			}

			var tabela = this.byId("tabela_jogadores")
			var items = tabela.getBinding("items");
			items.filter(filtro);
			
		}
	
	});

});