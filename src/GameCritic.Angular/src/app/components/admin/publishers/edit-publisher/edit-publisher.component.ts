import { validateHorizontalPosition } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PublishersModule } from 'src/app/components/publishers/publishers.module';
import { countries } from 'src/app/models/publisher/country-data-store';
import { Publisher } from 'src/app/models/publisher/publisher';
import { UpdatePublisher } from 'src/app/models/publisher/update-publisher';
import { PublisherService } from 'src/app/services/publisher.service';
import { StringUtils } from 'turbocommons-ts';

@Component({
  selector: 'app-edit-publisher',
  templateUrl: './edit-publisher.component.html',
  styleUrls: ['./edit-publisher.component.css']
})
export class EditPublisherComponent implements OnInit {

  public id!: number;
  public pageTitle: string;
  public publisherForm: FormGroup;
  public countries = countries;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private publisherService: PublisherService,
  ) { }

  ngOnInit() {
    let objectId!: number;
    this.route.params.subscribe(params => {
      objectId = +params['id'];
      if (objectId === 0) {
        this.pageTitle = 'Add Publisher :';
      } else {
        this.getPublisher(objectId);
        this.pageTitle = 'Edit Publisher :';
        this.id = objectId;
      }
    });

    this.publisherForm = this.formBuilder.group({
      id: [objectId, [Validators.required]],
      name: [null, [Validators.required, Validators.maxLength(50)]],
      country: [null, [Validators.required]],
      foundationYear: [null, [Validators.required, Validators.min(1970), Validators.max(2023)]],
      websiteUrl: [null, [this.validUrl]],
      numberOfEmployees: [null, [Validators.required, Validators.max(200000), Validators.min(50)]],
    });
  }

  getPublisher(id: number): void {
    this.publisherService.getPublisherById(id.toString()).subscribe((publisher: Publisher) => {
      this.publisherForm.controls['name'].setValue(publisher.name);
      this.publisherForm.controls['country'].setValue(publisher.country);
      this.publisherForm.controls['foundationYear'].setValue(publisher.foundationYear);
      this.publisherForm.controls['id'].setValue(publisher.id);
      this.publisherForm.controls['numberOfEmployees'].setValue(publisher.numberOfEmployees);
      this.publisherForm.controls['websiteUrl'].setValue(publisher.websiteURL);
    });
  }

  savePublisher(): void {
    if (this.publisherForm.dirty && this.publisherForm.valid) {
      let publisherToSave: UpdatePublisher;
      publisherToSave = {
        ...this.publisherForm.value
      };
      if (publisherToSave.websiteUrl == '') publisherToSave.websiteUrl = undefined;
      this.publisherService.savePublisher(publisherToSave).subscribe(
        () => this.onSaveComplete()
      );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.publisherForm.reset();
    this.router.navigate(['/publishers']);
  }

  validUrl(control: AbstractControl): ValidationErrors | null {
    if (control.value === '' || control.value === undefined || control.value === null) return null;
    if (!StringUtils.isUrl(control.value as string)) {
      return { validUrl: true };
    }
    return null;
  }

  get country() {
    return this.publisherForm.get('country');
  }
}
