import { HttpClient } from "@angular/common/http";
import { Component, Input, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { EnumTranslatorService } from "src/app/shared/services/enum-tranlator.service";
import { EnvironmentUrlService } from "src/app/shared/services/environment-url.service";

@Component({
    templateUrl: 'item-add-modal.component.html'
  })
  export class ItemAddModalComponent implements OnInit {
    @Input() brandsList:any[] = [];
  
    itemForm: FormGroup;
    sexDictionary: any;

    constructor(public activeModal: NgbActiveModal,private enumTranslator: EnumTranslatorService,private http: HttpClient,private envUrl: EnvironmentUrlService,) {
      this.itemForm = new FormGroup({});
      this.sexDictionary = this.enumTranslator.SexDictionary;
    }

    ngOnInit(): void {
        this.itemForm = new FormGroup({
            ID_item: new FormControl('', [Validators.required]),
            ID_brand: new FormControl('', [Validators.required]),
            itemName: new FormControl('', [Validators.required]),
            style: new FormControl('', [Validators.required]),
            stock: new FormControl('', [Validators.required]),
            size: new FormControl('', [Validators.required]),
            discount: new FormControl('', [Validators.required]),
            vat: new FormControl('', [Validators.required]),
            nettPrice: new FormControl('', [Validators.required]),
            colour: new FormControl('', [Validators.required]),
            sex: new FormControl('', [Validators.required])
        });
    }

    public addItem = (formValue: any) => {
        //this.showError = false;
        const formValues = { ...formValue };
    
        const item: any = {
            ID_Item: formValues.ID_item,
            ID_Brand: formValues.ID_brand,
            ItemName: formValues.itemName,
            Style: formValues.style,
            Stock: formValues.stock,
            Size: formValues.size,
            Discount: formValues.discount,
            VAT: formValues.vat,
            NettPrice: formValues.nettPrice,
            Colour: formValues.colour,
            Sex: formValues.sex
        };
    
        this.http.post<any>(`${this.envUrl.urlAddress}/Items/InsertItem`,item).subscribe(result => {
            this.activeModal.close('On success');
          }, error => console.error(error));
      }

      public hasError = (controlName: string, errorName: string) => {
        const controlValue = this.itemForm.get(controlName);
        return controlValue && controlValue.hasError(errorName)
      }

      public validateControl = (controlName: string) => {
        const controlValue = this.itemForm.get(controlName);
        return controlValue && controlValue.invalid && controlValue.touched
      }
  }