import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SuperHero } from './model/superhero';
import { Observable } from 'rxjs';
import { SuperHeroService } from './service/super-hero.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  http = inject(HttpClient);
  url = 'http://localhost:5065';
  superheroes$?: Observable<SuperHero[]>;
  superHero?: SuperHero;
  selectedSuperHero?: SuperHero;
  successMessage?: string;
  errorMessage?: string;
  superPowers: any[] = [];
  selectedSuperPowers: string[] = [];

  constructor(private superHeroService: SuperHeroService) {}

  ngOnInit(): void {
    this.getSuperHeroes();
    this.fetchSuperPowers();
  }

  getSuperHeroes() {
    this.superheroes$ = this.http.get<SuperHero[]>(`${this.url}/superhero`);
  }

  fetchSuperPowers() {
    this.superHeroService.getSuperPowers().subscribe(
      data => {
        this.superPowers = data;
      },
      error => {
        console.error('Error fetching super powers', error);
        this.errorMessage = error;
      }
    );
  }

  addSuperHero(event: Event) {
    event.preventDefault();
    const form = event.target as HTMLFormElement;
    const name = (form.elements.namedItem('name') as HTMLInputElement).value;
    const heroName = (form.elements.namedItem('heroname') as HTMLInputElement).value;
    const birthDate = (form.elements.namedItem('birthdate') as HTMLInputElement).value;
    const height = parseFloat((form.elements.namedItem('height') as HTMLInputElement).value);
    const weight = parseFloat((form.elements.namedItem('weight') as HTMLInputElement).value);

    const newSuperHero = {
      name,
      heroName,
      birthDate,
      height,
      weight,
      superPowerIds: this.selectedSuperPowers,
      superPowerNames: []
    };

    this.superHeroService.addSuperHero(newSuperHero).subscribe(
      response => {
        console.log('Super hero added successfully', response);
        this.errorMessage = undefined;
        this.successMessage = 'Super hero added successfully';
        this.listAllSuperHeroes();

        form.reset();
        this.selectedSuperPowers = [];

        setTimeout(() => {
          this.successMessage = undefined;
        }, 6000);
      },
      error => {
        console.error('Error adding super hero', error);
        this.errorMessage = error;
        this.successMessage = undefined;
      }
    );
  }

  editSuperHero(superhero: SuperHero) {
    this.selectedSuperHero = { ...superhero };
  }

  listAllSuperHeroes() {
    this.superheroes$ = this.superHeroService.getAllSuperHeroes();
  }

  updateSuperHero(event: Event) {
    event.preventDefault();
    const form = event.target as HTMLFormElement;
    const name = (form.elements.namedItem('name') as HTMLInputElement).value;
    const heroName = (form.elements.namedItem('heroname') as HTMLInputElement).value;
    const birthDate = (form.elements.namedItem('birthdate') as HTMLInputElement).value;
    const height = parseFloat((form.elements.namedItem('height') as HTMLInputElement).value);
    const weight = parseFloat((form.elements.namedItem('weight') as HTMLInputElement).value);

    const birthDateObj = new Date(birthDate);
    const updateSuperHero = { id: this.selectedSuperHero?.id, name, heroName, birthDate: birthDateObj, height, weight };

    this.superHeroService.updateSuperHero(updateSuperHero).subscribe(
      response => {
        console.log('Super hero updated successfully', response);
        this.errorMessage = undefined;
        this.selectedSuperHero = undefined;
        this.successMessage = 'Super hero updated successfully';
        this.listAllSuperHeroes();

        setTimeout(() => {
          this.successMessage = undefined;
        }, 6000);
      },
      error => {
        console.error('Error updating super hero', error);
        this.errorMessage = error;
        this.successMessage = undefined;
      }
    );
  }

  deleteSuperHero(id: string) {
    this.superHeroService.deleteSuperHeroById(id).subscribe(
      response => {
        console.log('Super hero deleted successfully', response);
        this.errorMessage = undefined;
        this.successMessage = 'Super hero deleted successfully';
        this.listAllSuperHeroes();

        setTimeout(() => {
          this.successMessage = undefined;
        }, 6000);

      },
      error => {
        console.error('Error deleting super hero', error);
        this.errorMessage = error;
        this.successMessage = undefined;
      }
    );
  }

  onInput(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const id = inputElement.value;
    if (!id) {
      this.superHero = undefined;
      this.errorMessage = undefined;
    }
  }

  onEnter(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const id = inputElement.value;

    if (id) {
      this.superHeroService.getSuperHeroById(id).subscribe(
        hero => {
          this.superHero = hero;
          this.errorMessage = undefined;
        },
        error => {
          this.superHero = undefined;
          this.errorMessage = error;
        }
      );
    } else {
      this.superHero = undefined;
      this.errorMessage = undefined;
    }
  }
}

