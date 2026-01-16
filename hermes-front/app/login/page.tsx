// TODO: improve error handling 

"use client"
import {Button} from '@/components/shadcn/ui/button';
import { Input } from '@/components/shadcn/ui/input';
import { Link, Loader2 } from 'lucide-react';
import { useRouter } from 'next/navigation'
import { LoginCredentials, useAuth } from '@/hooks/use-auth';
import { useState } from 'react';
import { toast } from 'sonner';

export default function LoginScreen() {
    const router = useRouter()
    const {login} = useAuth()
    const [credentials, setCredentials] = useState<LoginCredentials>({
        username: '',
        password: '',
    })
    const [isLoading, setIsLoading] = useState(false);
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setIsLoading(true);

        try {
            const formData = new FormData(e.currentTarget);
            const data = Object.fromEntries(formData.entries()) as unknown as LoginCredentials;
            const jwtToken = await login(data);
            toast.success("Login Successful", {});
            router.push("/");
            // TODO: persist jwt token
        } catch (error : any) {
            if (error.status == 401) 
            {
                toast.error("Acesso Negado", {
                description: "Usuário ou senha inválidos.",});
            }
            else 
            {
                toast.error("Erro de Conexão", {
                    description: "Não foi possível alcançar o servidor Hermes.",
                });
            }
        } finally {
            setIsLoading(false)
        }
    }


    return (
        <div className="flex flex-col items-center justify-center min-h-screen px-4 py-12">
            {/* Title Section */}
            <div className='text-center mb-12 max-w-2xl'>
                <h1 className="scroll-m-20 text-3xl md:text-5xl font-extrabold tracking-tight text-balance">
                    <span className="text-orange-400">HERMES:</span> Urban Dispatching System
                </h1>
            </div>

            <form
                onSubmit={handleSubmit}
                className="w-full max-w-sm space-y-4"
            >
                <div className="space-y-2">
                    <Input name="username" placeholder="Username"  required aria-label="Username"/>
                    <Input name="password" type="password" placeholder="Password" aria-label="Password" />
                </div>
                <div className="flex flex-col space-y-2">

                    <Button 
                        type="submit"
                        variant="outline" 
                        className="w-full h-12 cursor-pointer"
                    >
                        {isLoading ? (
                            <>
                                <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                                Please wait...
                            </>
                        ) : (
                            "Login"
                        )}                    
                    </Button>

                    <Button 
                    onClick={() => router.push("/recovery")}
                    type="button"
                    variant="link" 
                    disabled={isLoading}
                    className="text-muted-foreground cursor-pointer">
                        Forgot your password?
                    </Button>
                    
                </div>
            </form>
            <footer className="py-6 text-center text-sm text-muted-foreground">
                <p>© 2026 Hermes Urban Logistics. Todos os direitos reservados.</p>
            </footer>
        </div>
    )
}