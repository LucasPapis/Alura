// Exemplo de como pode ser resolvido um conflito em nomes de objetos criando alias no using.
// Esse metodo é bom pelo motivo de não precisar de ficar toda vez digitando o caminho completo do arquivo para declara-lo.

using VideoA = VideoFlix.PlataformaA.Video;
using VideoB = VideoFlix.PlataformaB.Video;

VideoA videoA = new VideoA();
VideoB videoB = new VideoB();