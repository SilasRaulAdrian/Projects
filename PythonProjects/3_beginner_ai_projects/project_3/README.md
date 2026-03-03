# AI Image Classifier

A **Streamlit** web app that uses a pre-trained **MobileNetV2** neural network to classify the contents of any uploaded image — no training required, runs entirely on your machine.

---

## How It Works

The app loads **MobileNetV2**, a lightweight convolutional neural network pre-trained on **ImageNet** (1000 object categories). When you upload an image, it is preprocessed to match the model's expected input format, passed through the network, and the top 3 predictions are returned with confidence scores.

### Flow

```
User uploads image (JPG / PNG)
        ↓
Image is resized to 224x224 pixels (MobileNetV2 input size)
        ↓
Pixel values are normalized via MobileNetV2 preprocess_input
        ↓
Model runs inference → raw prediction scores for 1000 classes
        ↓
Top 3 predictions decoded with human-readable labels
        ↓
Results displayed with confidence percentages
```

### Model Details

| Property | Value |
|---|---|
| Architecture | MobileNetV2 |
| Trained on | ImageNet (1000 classes) |
| Input size | 224 × 224 px |
| Output | Top-3 class labels + confidence scores |
| Weights | Downloaded automatically on first run |

---

## Requirements

- Python 3.9+
- A machine with enough RAM to load MobileNetV2 (~14 MB weights)

### Install dependencies

```bash
pip install streamlit tensorflow opencv-python pillow numpy
```

---

## Usage

Start the Streamlit app:

```bash
streamlit run app.py
```

Your browser will open automatically at `http://localhost:8501`.

### Steps in the UI

1. **Upload an image** — supports `.jpg`, `.jpeg`, and `.png`
2. Preview the uploaded image on screen
3. Click **Classify Image**
4. View the **top 3 predictions** with confidence percentages

### Example output

```
Predictions:
golden_retriever:  91.34%
Labrador_retriever: 5.12%
tennis_ball:        1.03%
```

---

## Project Structure

```
.
├── app.py        # Main Streamlit application
└── README.md     # This file
```

---

## Notes

- The model weights are **downloaded automatically** from Keras on the first run and cached locally — no manual download needed.
- The model is cached with `@st.cache_resource`, so it loads only once per session, keeping the app fast.
- MobileNetV2 is optimized for speed and works well on CPU — no GPU required.
- Classification is limited to the **1000 ImageNet categories** (everyday objects, animals, vehicles, food, etc.). It cannot identify people by name or recognize custom/domain-specific objects.
- For best results, use clear, well-lit images where the main subject is centered.
