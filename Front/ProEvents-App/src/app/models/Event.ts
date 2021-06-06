import { Lot } from "./Lot";
import { SocialNetwork } from "./SocialNetwork";
import { Speaker } from "./Speaker";

export interface Event {
  id: number;
  local: string;
  date?: Date;
  subject: string;
  amountOfPeople: number;
  imageUrl: string;
  phone: string;
  email: string;
  lots: Lot[];
  socialNetworks: SocialNetwork[];
  speakerEvents: Speaker[];
}
