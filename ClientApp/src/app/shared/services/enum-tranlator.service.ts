import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class EnumTranslatorService {
    public SexEnum(value:number):string {
        switch(value) {
            case 1:
                return 'Męskie';
            case 2:
                return 'Damskie';
            case 3:
                return 'Unisex';
            case 4:
                return 'Chłopięce';
            case 5:
                return 'Dziewczęce';
            case 6:
                return 'Dziecięce';
            default: case 1:           
                return 'b.d.';
        }
    }
}