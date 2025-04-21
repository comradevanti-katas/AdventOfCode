import {Dir} from './domain';

export const parseDir = (s: string) => {
  if (s === 'R') {
    return Dir.Right;
  }

  if (s === 'L') {
    return Dir.Left;
  }

  throw new Error('Bad Direction Input');
};

export const parseInstruction = (s: string) => {

  const dir = parseDir(s.substring(0, 1));
  const dist = parseInt(s.substring(1));
  return {dir: dir, dist: dist};

};
