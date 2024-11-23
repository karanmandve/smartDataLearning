import { Component, Inject, OnDestroy, OnInit, Optional } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { IAppResponseDto, SubSinkService, ToastMessageService } from '@core-services';

import { ExaminationTypeService } from '../../services';
import { IExaminationTypeDto } from '../../models';

@Component({
  selector: 'app-examination-type-add-update',
  templateUrl: './examination-type-add-update.component.html',
  styleUrl: './examination-type-add-update.component.scss'
})
export class ExaminationTypeAddUpdateComponent implements OnInit, OnDestroy {
  private readonly subSink: SubSinkService = new SubSinkService();
  isEditMode: boolean = false;
  examinationTypeForm!: FormGroup;
  isSaving: boolean = false;

  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) private readonly _inputData: IExaminationTypeDto | null | undefined,
    private readonly _formBuilder: FormBuilder,
    private readonly _examinationTypeService: ExaminationTypeService,
    private readonly _toastMessageService: ToastMessageService,
    private readonly _dialogRef: MatDialogRef<ExaminationTypeAddUpdateComponent>,
  ) { }

  ngOnInit() {
    this.createExaminationTypeForm();

    if (this._inputData && ((this._inputData.examinationTypeId || 0) > 0))
      this.isEditMode = true;

    if (this._inputData)
      this.patchExaminationTypeForm(this._inputData);
  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }

  onSubmitEvent(): void {
    if (this.examinationTypeForm.invalid)
      return;

    const examinationType: IExaminationTypeDto = this.getDataUsingExaminationTypeForm();

    let request = this._examinationTypeService
      .addExaminationType<IAppResponseDto>(examinationType);

    if ((examinationType.examinationTypeId || 0) > 0)
      request = this._examinationTypeService
        .updateExaminationType<IAppResponseDto>(examinationType);

    this.isSaving = true;
    this.subSink.sink = request
      .subscribe({
        next: (response: IAppResponseDto) => {
          this.isSaving = false;

          if (!response.isSuccess) {
            this._toastMessageService.add({
              summary: 'Warning',
              detail: response.message,
              severity: 'warning'
            });

            return;
          }

          this._toastMessageService.add({
            summary: 'Success',
            detail: response.message || 'Examination Type saved successfully.',
            severity: 'success'
          });

          this._dialogRef.close("success");
        },
        error: err => {
          this.isSaving = false;
        }
      });
  }

  onCloseEvent(): void {
    this._dialogRef.close();
  }

  private getDataUsingExaminationTypeForm(): IExaminationTypeDto {
    const examinationType: IExaminationTypeDto = this.examinationTypeForm.getRawValue();
    return examinationType;
  }

  private patchExaminationTypeForm(examinationType: IExaminationTypeDto) {
    this.examinationTypeForm.patchValue(examinationType);
  }

  private createExaminationTypeForm() {
    this.examinationTypeForm = this._formBuilder.group({
      examinationTypeId: [0, Validators.required],
      mentalStatusExaminationId: [0, Validators.required],
      mentalTypeName: ['', Validators.required],
    });
  }
}
