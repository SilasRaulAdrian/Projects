const multer = require("multer");
const path = require("path");
const uuid = require("uuid").v4;

// destination dir
const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    console.log("Receiving file: ", file.originalname);
    console.log("Fieldname: ", file.fieldname);
    if (file.fieldname === "video") {
      const rootDir = path.dirname(require.main.filename);
      const targetPath = path.join(rootDir, "public/videos");
      console.log("Saving to: ", targetPath);
      cb(null, targetPath);
    } else {
      cb(new Error("Invalid field name"), null);
    }
  },
  filename: (req, file, cb) => {
    const videoExt = file.mimetype.split("/")[1];
    const id = uuid();
    cb(null, "video_" + id + "." + videoExt);
  },
});

const fileFilter = (req, file, cb) => {
  if (file.mimetype === "video/mp4") {
    cb(null, true);
  } else {
    cb(null, false);
  }
};
exports.videoUpload = multer({ storage, fileFilter });
