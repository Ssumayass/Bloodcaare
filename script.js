async function getDataFromApi() {
    try {
        const response = await fetch('/api/Api/getData');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const data = await response.json();
        console.log('Data from C# method:', data);
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}

// Anropa funktionen för att hämta data från C#-metoden
getDataFromApi();
