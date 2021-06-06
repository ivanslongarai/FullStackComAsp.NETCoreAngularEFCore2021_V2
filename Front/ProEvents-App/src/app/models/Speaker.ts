import { SocialNetwork } from "./SocialNetwork";

export interface Speaker {
  id: number;
  name: string;
  miniResume: string;
  imageUrl: string;
  phone: string;
  email: string;
  socialNetworks: SocialNetwork[];
  speakerEvents: Event[];
}
