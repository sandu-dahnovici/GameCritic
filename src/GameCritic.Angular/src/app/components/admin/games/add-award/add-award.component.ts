import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AwardList } from 'src/app/models/award/award-list';
import { AwardService } from 'src/app/services/award.service';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-add-award',
  templateUrl: './add-award.component.html',
  styleUrls: ['./add-award.component.css']
})
export class AddAwardComponent implements OnInit {
  id!: number;
  awards: AwardList[];
  pageTitle: string;
  awardForm: FormGroup;

  constructor(private awardService: AwardService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private gameService: GameService) { }

  ngOnInit(): void {
    let objectId!: number;
    this.route.params.subscribe(params => {
      objectId = +params['id'];
      this.id = objectId;
      this.awardService.getAvailableAwardsByGameId(this.id).subscribe((awards) => {
        this.awards = awards;
      });
      this.gameService.getGameById(this.id.toString()).subscribe((game) => {
        this.pageTitle = `Add award for ${game.title}`;
      });
    });

    this.awardForm = this.formBuilder.group({
      id: [objectId, [Validators.required]],
      awardId: [null, [Validators.required]],
      rank: [null, [Validators.max(50), Validators.min(1), Validators.required]]
    });
  }

  saveRanking() {

  }

  get awardId() {
    return this.awardForm.get('awardId');
  }

}
