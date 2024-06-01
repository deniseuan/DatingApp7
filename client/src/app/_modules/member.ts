import { Photo } from "./photo";

export class Member {
  id: number;
  userName: string;
  photoUrl: string;
  age: number;
  knownAs: string;
  created: string;
  lastActive: string;
  gender: string;
  introduction: string;
  lookingFor: string;
  interests: string;
  city: string;
  country: string;
  photos: Photo[];

  constructor(
    id: number,
    userName: string,
    photoUrl: string,
    age: number,
    knownAs: string,
    created: string,
    lastActive: string,
    gender: string,
    introduction: string,
    lookingFor: string,
    interests: string,
    city: string,
    country: string,
    photos: Photo[],
  ) {
    this.id = id;
    this.userName = userName;
    this.photoUrl = photoUrl;
    this.age = age;
    this.knownAs = knownAs;
    this.created = created;
    this.lastActive = lastActive;
    this.gender = gender;
    this.introduction = introduction;
    this.lookingFor = lookingFor;
    this.interests = interests;
    this.city = city;
    this.country = country;
    this.photos = photos;
  }
  
}
