sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
 ], function (Controller,formatter,Filter,FilterOperator) {
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
			
		}
    });
 });