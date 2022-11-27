import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AwardList } from 'src/app/models/award/award-list';
import { UpdateRanking } from 'src/app/models/ranking/update-ranking';
import { AwardService } from 'src/app/services/award.service';
import { GameService } from 'src/app/services/game.service';
import { RankingService } from 'src/app/services/ranking.service';

@Component({
  selector: 'app-add-award',
  templateUrl: './add-award.component.html',
  styleUrls: ['./add-award.component.css']
})
export class AddAwardComponent implements OnInit {
  id!: number;
  awards: AwardList[];
  ranks: number[];
  pageTitle: string;
  awardForm: FormGroup;

  constructor(private awardService: AwardService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private gameService: GameService,
    private rankingService: RankingService,
    private router : Router) { }

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
    const rank: UpdateRanking = {
      ...this.awardForm.value
    };
    rank.gameId = this.id;

    this.rankingService.createRanking(rank).subscribe(
      () => this.onSaveComplete()
    );
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.awardForm.reset();
    this.router.navigate(['/games',this.id]);
  }

  awardChangeAction(awardId: number) {
    this.rankingService.getAvailableRanksByAwardId(awardId).subscribe((ranks) => {
      this.ranks = ranks;
    });
  }

  get awardId() {
    return this.awardForm.get('awardId');
  }

  get rank() {
    return this.awardForm.get('rank');
  }

}
