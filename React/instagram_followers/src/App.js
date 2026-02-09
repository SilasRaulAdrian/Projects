import React, { useState } from "react";
import {
  Upload,
  Users,
  UserMinus,
  AlertCircle,
  CheckCircle,
} from "lucide-react";

function App() {
  const [following, setFollowing] = useState([]);
  const [followers, setFollowers] = useState([]);
  const [notFollowingBack, setNotFollowingBack] = useState([]);
  const [step, setStep] = useState(1);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const handleFileUpload = async (e, type) => {
    const file = e.target.files[0];
    if (!file) return;

    try {
      const text = await file.text();
      const data = JSON.parse(text);

      let usernames = [];

      if (type === "following" && data.relationships_following) {
        usernames = data.relationships_following
          .map((item) => item.title)
          .filter((val) => val && typeof val === "string");
      } else if (type === "followers") {
        if (Array.isArray(data)) {
          usernames = data
            .map((item) => item.title || item.string_list_data?.[0]?.value)
            .filter((val) => val && typeof val === "string");
        } else if (data.relationships_followers) {
          usernames = data.relationships_followers
            .map((item) => item.title)
            .filter((val) => val && typeof val === "string");
        } else {
          const possibleArray = Object.values(data).find((val) =>
            Array.isArray(val)
          );
          if (possibleArray) {
            usernames = possibleArray
              .map((item) => item.title || item.string_list_data?.[0]?.value)
              .filter((val) => val && typeof val === "string");
          }
        }
      }

      console.log(`${type} loaded:`, usernames.length, "users");
      console.log("First 5 users:", usernames.slice(0, 5));

      if (usernames.length === 0) {
        setError(
          `Nu am găsit username-uri în fișierul ${type}. Verifică structura fișierului!`
        );
        return;
      }

      if (type === "following") {
        setFollowing(usernames);
        setStep(2);
      } else {
        setFollowers(usernames);
        setStep(3);
      }

      setError("");
    } catch (err) {
      setError(`Eroare la citirea fișierului ${type}: ${err.message}`);
    }
  };

  const analyzeFollows = () => {
    if (following.length === 0 || followers.length === 0) {
      setError("Te rog să încarci ambele fișiere înainte de analiză!");
      return;
    }

    setLoading(true);
    setError("");

    setTimeout(() => {
      const validFollowers = followers
        .filter((f) => f && typeof f === "string")
        .map((f) => f.toLowerCase().trim());

      const followerSet = new Set(validFollowers);

      const notFollowingBackList = following
        .filter((user) => user && typeof user === "string")
        .filter((user) => !followerSet.has(user.toLowerCase().trim()));

      setNotFollowingBack(notFollowingBackList);
      setLoading(false);
      setStep(4);
    }, 500);
  };

  const resetApp = () => {
    setFollowing([]);
    setFollowers([]);
    setNotFollowingBack([]);
    setStep(1);
    setLoading(false);
    setError("");
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-purple-50 via-pink-50 to-orange-50 p-6">
      <div className="max-w-4xl mx-auto">
        <div className="text-center mb-8">
          <div className="flex items-center justify-center gap-3 mb-4">
            <Users className="w-10 h-10 text-purple-600" />
            <h1 className="text-4xl font-bold text-gray-800">
              Verificator Instagram Follow
            </h1>
          </div>
          <p className="text-gray-600">
            Descoperă cine nu te urmărește înapoi pe Instagram
          </p>
        </div>

        {error && (
          <div className="mb-6 p-4 bg-red-50 border border-red-200 rounded-lg flex items-start gap-3">
            <AlertCircle className="w-5 h-5 text-red-600 mt-0.5" />
            <p className="text-red-800">{error}</p>
          </div>
        )}

        <div className="bg-white rounded-2xl shadow-xl p-8 mb-6">
          {step === 1 && (
            <div className="space-y-6">
              <div className="text-center">
                <div className="inline-block p-4 bg-purple-100 rounded-full mb-4">
                  <Upload className="w-8 h-8 text-purple-600" />
                </div>
                <h2 className="text-2xl font-semibold mb-2">
                  Pasul 1: Încarcă lista de Following
                </h2>
                <p className="text-gray-600 mb-6">
                  Încarcă fișierul JSON cu persoanele pe care le urmărești
                </p>
              </div>

              <label className="block">
                <div className="border-2 border-dashed border-purple-300 rounded-lg p-8 text-center hover:border-purple-500 transition cursor-pointer bg-purple-50">
                  <Upload className="w-12 h-12 text-purple-400 mx-auto mb-3" />
                  <p className="text-gray-700 font-medium mb-1">
                    Click pentru a încărca following.json
                  </p>
                  <p className="text-sm text-gray-500">
                    Fișier JSON cu lista de following
                  </p>
                  <input
                    type="file"
                    accept=".json"
                    onChange={(e) => handleFileUpload(e, "following")}
                    className="hidden"
                  />
                </div>
              </label>

              <div className="bg-blue-50 border border-blue-200 rounded-lg p-4 mt-6">
                <h3 className="font-semibold text-blue-900 mb-2">
                  Cum obții datele?
                </h3>
                <ol className="text-sm text-blue-800 space-y-1 list-decimal list-inside">
                  <li>Intră pe Instagram → Setări → Securitate</li>
                  <li>Descarcă datele tale (Download Your Information)</li>
                  <li>Alege formatul JSON</li>
                  <li>Extrage fișierele: following.json și followers.json</li>
                </ol>
              </div>
            </div>
          )}

          {step === 2 && (
            <div className="space-y-6">
              <div className="text-center">
                <CheckCircle className="w-12 h-12 text-green-600 mx-auto mb-4" />
                <h2 className="text-2xl font-semibold mb-2">
                  Pasul 2: Încarcă lista de Followers
                </h2>
                <p className="text-gray-600 mb-2">
                  Încarcă fișierul JSON cu persoanele care te urmăresc
                </p>
                <p className="text-green-600 font-medium mb-6">
                  ✓ {following.length} persoane în following
                </p>
              </div>

              <label className="block">
                <div className="border-2 border-dashed border-pink-300 rounded-lg p-8 text-center hover:border-pink-500 transition cursor-pointer bg-pink-50">
                  <Upload className="w-12 h-12 text-pink-400 mx-auto mb-3" />
                  <p className="text-gray-700 font-medium mb-1">
                    Click pentru a încărca followers.json
                  </p>
                  <p className="text-sm text-gray-500">
                    Fișier JSON cu lista de followers
                  </p>
                  <input
                    type="file"
                    accept=".json"
                    onChange={(e) => handleFileUpload(e, "followers")}
                    className="hidden"
                  />
                </div>
              </label>
            </div>
          )}

          {step === 3 && (
            <div className="space-y-6 text-center">
              <CheckCircle className="w-12 h-12 text-green-600 mx-auto" />
              <div>
                <h2 className="text-2xl font-semibold mb-4">
                  Gata de analiză!
                </h2>
                <div className="space-y-2 text-lg mb-6">
                  <p className="text-gray-700">
                    ✓{" "}
                    <span className="font-semibold text-purple-600">
                      {following.length}
                    </span>{" "}
                    persoane în following
                  </p>
                  <p className="text-gray-700">
                    ✓{" "}
                    <span className="font-semibold text-pink-600">
                      {followers.length}
                    </span>{" "}
                    persoane în followers
                  </p>
                </div>
                <button
                  onClick={analyzeFollows}
                  disabled={loading}
                  className="px-8 py-3 bg-gradient-to-r from-purple-600 to-pink-600 text-white rounded-lg font-semibold hover:from-purple-700 hover:to-pink-700 transition disabled:opacity-50"
                >
                  {loading ? "Se analizează..." : "Analizează acum"}
                </button>
              </div>
            </div>
          )}

          {step === 4 && (
            <div className="space-y-6">
              <div className="text-center mb-6">
                <UserMinus className="w-12 h-12 text-orange-600 mx-auto mb-4" />
                <h2 className="text-2xl font-semibold mb-2">Rezultate</h2>
                <p className="text-3xl font-bold text-orange-600 mb-2">
                  {notFollowingBack.length}
                </p>
                <p className="text-gray-600">
                  {notFollowingBack.length === 1
                    ? "persoană nu te urmărește înapoi"
                    : "persoane nu te urmăresc înapoi"}
                </p>
              </div>

              {notFollowingBack.length > 0 && (
                <div className="max-h-96 overflow-y-auto">
                  <div className="grid gap-2">
                    {notFollowingBack.map((user, idx) => (
                      <div
                        key={idx}
                        className="flex items-center justify-between p-3 bg-gray-50 rounded-lg hover:bg-gray-100 transition"
                      >
                        <span className="font-medium text-gray-800">
                          @{user}
                        </span>
                        <a
                          href={`https://instagram.com/${user}`}
                          target="_blank"
                          rel="noopener noreferrer"
                          className="text-purple-600 hover:text-purple-700 text-sm font-medium"
                        >
                          Vezi profil →
                        </a>
                      </div>
                    ))}
                  </div>
                </div>
              )}

              {notFollowingBack.length === 0 && (
                <div className="text-center py-8">
                  <CheckCircle className="w-16 h-16 text-green-500 mx-auto mb-4" />
                  <p className="text-xl text-gray-700">
                    Toți te urmăresc înapoi! 🎉
                  </p>
                </div>
              )}

              <button
                onClick={resetApp}
                className="w-full py-3 bg-gray-200 text-gray-800 rounded-lg font-semibold hover:bg-gray-300 transition mt-6"
              >
                Verifică din nou
              </button>
            </div>
          )}
        </div>

        <div className="text-center text-sm text-gray-500">
          <p>Datele tale rămân private - analiza se face local în browser</p>
        </div>
      </div>
    </div>
  );
}

export default App;
