import moment from "moment";

const indiaLocations = [
    {
        location: "Delhi",
        bestTouristSpot: "Red Fort",
        spotInfo: "The Red Fort is a historic fort in Old Delhi, built by Emperor Shah Jahan. It is a UNESCO World Heritage Site with impressive architecture and a rich history.",
    },
    {
        location: "Mumbai",
        bestTouristSpot: "Gateway of India",
        spotInfo: "The Gateway of India is an iconic monument in Mumbai, built to commemorate the visit of King George V and Queen Mary to India. It stands as a symbol of India's colonial history.",
    },
    {
        location: "Jaipur",
        bestTouristSpot: "Hawa Mahal",
        spotInfo: "Hawa Mahal, also known as the Palace of Winds, is a stunning palace in Jaipur. It was built with intricate windows to allow royal ladies to observe daily life.",
    },
    {
        location: "Goa",
        bestTouristSpot: "Calangute Beach",
        spotInfo: "Calangute Beach is one of the most popular beaches in Goa. It offers a beautiful coastline, golden sand, and a lively atmosphere with beachside shacks and cafes.",
    },
    {
        location: "Agra",
        bestTouristSpot: "Taj Mahal",
        spotInfo: "The Taj Mahal is a world-renowned monument in Agra, built by Emperor Shah Jahan in memory of his wife Mumtaz Mahal. It is a symbol of eternal love and exquisite Mughal architecture.",
    },
    // Add more locations and their best tourist spots and spotInfo here...
];

export const analyze = (text) => {
    if (text.includes("hi") || text.includes("hai") || text.includes("hello")) {
        return `Hi, How Can I Help You?`;
    } else if (text.includes("date")) {
        return moment().format("MMMM Do YYYY");
    } else if (text.includes("time")) {
        return moment().format("h:mm:ss a");
    } else if (text.toLowerCase().includes("thanks") || text.toLowerCase().includes("thank you")) {
        return `You're welcome! If you have any more questions or need assistance, feel free to ask.`;
    } else {
        const matchedLocation = indiaLocations.find((location) =>
            text.toLowerCase().includes(location.location.toLowerCase())
        );

        if (matchedLocation) {
            return [
                `You mentioned ${matchedLocation.location}. One of the best tourist spots in ${matchedLocation.location} is ${matchedLocation.bestTouristSpot}.`,
                matchedLocation.spotInfo,
            ];
        } else {
            return `I can't get you. Can you rephrase the message?`;
        }
    }
};



