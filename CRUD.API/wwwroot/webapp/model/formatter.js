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
    }
    }

});