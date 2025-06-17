import { useState, useEffect } from 'react'
import { FiSun, FiMoon } from 'react-icons/fi'

export function ThemeToggle() {
  const [darkMode, setDarkMode] = useState(() => {
    // Verifica preferência salva ou do sistema
    return localStorage.getItem('darkMode') === 'true' || 
      (window.matchMedia('(prefers-color-scheme: dark)').matches && !localStorage.getItem('darkMode'))
  })

  useEffect(() => {
    // Aplica a classe no HTML
    if (darkMode) {
      document.documentElement.classList.add('dark')
      localStorage.setItem('darkMode', 'true')
    } else {
      document.documentElement.classList.remove('dark')
      localStorage.setItem('darkMode', 'false')
    }
  }, [darkMode])

  return (
    <button
      onClick={() => setDarkMode(!darkMode)}
      className="p-2 rounded-full bg-gray-200 dark:bg-dark-700 text-gray-800 dark:text-gray-200"
      aria-label={darkMode ? 'Ativar modo claro' : 'Ativar modo escuro'}
    >
      {darkMode ? <FiSun size={20} /> : <FiMoon size={20} />}
    </button>
  )
}
