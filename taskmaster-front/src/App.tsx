import { useState } from 'react'
import { ThemeToggle } from './components/ThemeToggle'
import { FiCheckCircle, FiList, FiPlus } from 'react-icons/fi'

export default function App() {
  const [tasks, setTasks] = useState([
    { id: 1, title: 'Configurar dark mode', completed: true },
    { id: 2, title: 'Conectar com a API', completed: false },
    { id: 3, title: 'Deploy da aplicação', completed: false }
  ])

  return (
    <div className="min-h-screen bg-gray-50 dark:bg-gray-900 text-gray-900 dark:text-gray-100 transition-colors duration-200">
      {/* Header */}
      <header className="sticky top-0 z-10 bg-white/80 dark:bg-gray-800/80 backdrop-blur-sm border-b border-gray-200 dark:border-gray-700">
        <div className="container mx-auto px-4 py-4 flex justify-between items-center">
          <div className="flex items-center space-x-2">
            <FiList className="text-indigo-600 dark:text-indigo-400 text-2xl" />
            <h1 className="text-2xl font-bold bg-gradient-to-r from-indigo-600 to-purple-600 dark:from-indigo-400 dark:to-purple-400 bg-clip-text text-transparent">
              TaskMaster
            </h1>
          </div>
          <ThemeToggle />
        </div>
      </header>

      {/* Main Content */}
      <main className="container mx-auto px-4 py-8">
        <div className="max-w-2xl mx-auto">
          {/* Add Task Card */}
          <div className="bg-white dark:bg-gray-800 rounded-xl shadow-md p-6 mb-6">
            <div className="flex items-center space-x-4">
              <input
                type="text"
                placeholder="Nova tarefa..."
                className="flex-1 px-4 py-2 bg-gray-50 dark:bg-gray-700 rounded-lg border border-gray-200 dark:border-gray-600 focus:outline-none focus:ring-2 focus:ring-indigo-500"
              />
              <button className="p-2 bg-indigo-600 hover:bg-indigo-700 dark:bg-indigo-500 dark:hover:bg-indigo-600 text-white rounded-lg transition-colors">
                <FiPlus size={20} />
              </button>
            </div>
          </div>

          {/* Tasks List */}
          <div className="space-y-3">
            {tasks.map(task => (
              <div 
                key={task.id}
                className={`flex items-center p-4 rounded-lg shadow-sm border transition-all ${
                  task.completed 
                    ? 'bg-green-50/50 dark:bg-green-900/20 border-green-200 dark:border-green-800'
                    : 'bg-white dark:bg-gray-800 border-gray-200 dark:border-gray-700 hover:shadow-md'
                }`}
              >
                <button 
                  className={`p-2 rounded-full mr-3 ${
                    task.completed
                      ? 'text-green-600 dark:text-green-400 bg-green-100 dark:bg-green-900/50'
                      : 'text-gray-400 hover:text-indigo-600 dark:hover:text-indigo-400 hover:bg-gray-100 dark:hover:bg-gray-700'
                  }`}
                >
                  <FiCheckCircle size={20} />
                </button>
                <span className={`flex-1 ${
                  task.completed ? 'line-through text-gray-500 dark:text-gray-400' : ''
                }`}>
                  {task.title}
                </span>
                {!task.completed && (
                  <button className="text-gray-400 hover:text-red-500 p-2">
                    ×
                  </button>
                )}
              </div>
            ))}
          </div>
        </div>
      </main>

      {/* Footer */}
      <footer className="mt-12 py-6 border-t border-gray-200 dark:border-gray-800">
        <div className="container mx-auto px-4 text-center text-sm text-gray-500 dark:text-gray-400">
          <p>TaskMaster © {new Date().getFullYear()} - Todos os direitos reservados</p>
        </div>
      </footer>
    </div>
  )
}
