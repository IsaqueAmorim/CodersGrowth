sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	
], function (Controller,JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.api.jogadores.controller.App", {
		
		onInit : function(){

			var jsonModel = new JSONModel();
			fetch("https://localhost:7139/v1/jogadores/",{method: "GET"})
				.then(response => response.json())
				.then(response => jsonModel.setData({jogadores : response}))
			this.getView().setModel(jsonModel);
			
		}

	});

});