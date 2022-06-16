import { Component, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { CellClickedEvent, ColDef, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { AgGridAngular } from 'ag-grid-angular';
import { EnumTranslatorService } from 'src/app/shared/services/enum-tranlator.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ItemAddModalComponent } from '../item-add-modal/item-add-modal.component';

@Component({
  templateUrl: './items-management.component.html'
})
export class ItemsManagementComponent {
  public brandsList:any[] = [];
  public itemsList:any[] = [];
  public selectedItem:any;

  public columnDefs: ColDef[] = [
    { field: 'iD_Item', headerName: 'ID produktu' },
    { field: 'brands.brandName', headerName: 'Marka' },
    { field: 'itemName', headerName: 'Nazwa produktu' },
    { field: 'style', headerName: 'Rodzaj' },
    { field: 'sex', headerName: 'Płeć', valueFormatter: params => this.enumTranslator.SexEnum(params.value) },
    { field: 'colour', headerName: 'Kolor' },
    { field: 'nettPrice', headerName: 'Cena bazowa' },
    { field: 'vat', headerName: 'Stawka VAT', valueFormatter: params => `${params.value}%`},
    { field: 'discount', headerName: 'Rabat', valueFormatter: params => `${params.value}%` },
    { field: 'finalPrice', headerName: 'Końcowa cena', valueFormatter: params => `${params.data.nettPrice + (params.data.nettPrice*params.data.vat/100) - (params.data.nettPrice*params.data.discount/100)}` },
    { field: 'stock', headerName: 'Stan magazynowy' }
  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
  };

  public rowData$!: Observable<any[]>;

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  constructor(private http: HttpClient,private envUrl: EnvironmentUrlService, private enumTranslator: EnumTranslatorService,private modalService: NgbModal) {
    this.getBrands();
  }

  onGridReady(params: GridReadyEvent) {
    params.api.sizeColumnsToFit()
    this.rowData$ = this.http.get<any[]>(`${this.envUrl.urlAddress}/Items/GetItemsAllJson`);
  }
  
  onCellClicked( e: CellClickedEvent): void {
    console.log('cellClicked', e);
  }
  
  public addItem() {
    const modalRef = this.modalService.open(ItemAddModalComponent);
    modalRef.componentInstance.brandsList = this.brandsList;
  }

  public createItem() {

  }

  public getAllItems() {
    this.http.get<any[]>(`${this.envUrl.urlAddress}/Items/GetAllItemsJson`).subscribe(result => {
        this.itemsList = result;
      }, error => console.error(error));
  }

  public getBrands() {
    this.http.get<any[]>(`${this.envUrl.urlAddress}/Brands/GetBrandsAllJson`).subscribe(result => {
      this.brandsList = result;
    }, error => console.error(error));
  }

  public getItemDetails() {
    this.http.get<any[]>(`${this.envUrl.urlAddress}/Items/GetSingleItemJson`).subscribe(result => {
        this.selectedItem = result;
      }, error => console.error(error));
  }

}
