sap.ui.define([], function () {
	"use strict";

	return {

    eloImage: function (elo) {
        
        switch (elo){
            case 0: return "../assets/Ferro.svg"
            case 1: return "../assets/Bronze.svg"
            case 2: return "../assets/Prata.svg"
            case 3: return "../assets/Ouro.svg"
            case 4: return "../assets/Platina.svg"
            case 5: return "../assets/Diamante.svg"
            case 6: return "../assets/Mestre.svg"
            case 7: return "../assets/GM.svg    "
            case 8: return "../assets/Challenger.svg"
     
        }  
    },
    eloLegenda: function (elo) {
        switch (elo){
            case 0: return "Ferro"
            case 1: return "Bronze"
            case 2: return "Prata"
            case 3: return "Ouro"
            case 4: return "Platina"
            case 5: return "Diamante"
            case 6: return ".Mestre"
            case 7: return "Grão Mestre"
            case 8: return "Desafiante"
     
        } 
    }

}});