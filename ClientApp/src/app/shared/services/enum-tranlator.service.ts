import { Injectable } from "@angular/core";
import { find } from "lodash";

@Injectable({
    providedIn: 'root'
})
export class EnumTranslatorService {
    public SexDictionary = [
        {ID: 1, Name: 'Męskie'},
        {ID: 2, Name: 'Damskie'},
        {ID: 3, Name: 'Unisex'},
        {ID: 4, Name: 'Chłopięce'},
        {ID: 5, Name: 'Dziewczęce'},
        {ID: 6, Name: 'Dziecięce'}
    ]

    public SexEnum(value:number):string {
        if(!value) return 'b.d.';

        let sex = find(this.SexDictionary,{ ID: value });

        if(!sex) return 'b.d.';

        return sex.Name;
    }
}