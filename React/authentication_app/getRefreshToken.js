const { google } = require("googleapis");

const CLIENT_ID =
  "424708625933-3kf0toa6nbm1bg6ucatk74acuerehopt.apps.googleusercontent.com";
const CLIENT_SECRET = "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";
const REDIRECT_URI = "https://developers.google.com/oauthplayground";

const oAuth2Client = new google.auth.OAuth2(
  CLIENT_ID,
  CLIENT_SECRET,
  REDIRECT_URI
);

// Pasul 1: Obține link-ul de autorizare
const authUrl = oAuth2Client.generateAuthUrl({
  access_type: "offline",
  scope: ["https://mail.google.com/"],
});
console.log("Vizitează acest link pentru a obține codul:", authUrl);

// Pasul 2: Pune codul aici după ce îl obții
const code =
  "4/0AVMBsJgmBHc88qapzKDCNBy3cJ1w63qHqrCses-H42gz-9R23gLc9PPFYc0ILBys4l8QLw";

oAuth2Client.getToken(code, (err, token) => {
  if (err) return console.error("Eroare la obținerea tokenului", err);
  console.log("Refresh Token:", token.refresh_token);
});
