/** @type {import('tailwindcss').Config} */
export default {
  darkMode: 'class', // Habilita dark mode via classe
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        dark: {
          900: '#121212',
          800: '#1E1E1E',
          700: '#2D2D2D',
        }
      }
    },
  },
  plugins: [],
}
